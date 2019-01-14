using System;
using YoutubeChannelStream;
using Xamarin.Forms;
using CodeHollow.FeedReader;
using System.Collections.Generic;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace YoutubeChannelStream
{
	public class StreamPage : ContentPage
	{
		#region Fields
		Xamarin.Forms.ListView _listView = new Xamarin.Forms.ListView();
		List<FeedObject> _feeds = new List<FeedObject>();
		#endregion

		#region Constructor
		public StreamPage()
		{
			Title = "Youtube Channel Stream";

			// For iPhone X
			On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

			_listView.ItemSelected += listView_ItemSelected;
			_listView.SelectedItem = null;
			_listView.IsPullToRefreshEnabled = true;
			_listView.RefreshCommand = new Command(PullData); 
			// Default values to display if the feeds aren't loading
			var label = new Label();
			var stack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			stack.Children.Add(label);
			Content = stack;
			if (_feeds != null)
				PopulateList();
			else
				label.Text = "Either the feed is empty or the URL is incorrect.";
		}
		#endregion Constructor

		#region Private Functions & Event Handlers
		private async void PullData()
		{
			var rssFeeds = new Feed();
			try
			{
				rssFeeds = await FeedReader.ReadAsync("https://www.youtube.com/feeds/videos.xml?channel_id=UCwCOn0lguoGNEIwLgRpoPYw");
			}
			catch (Exception ex)
			{
				// Default values so to test and develop the first screen even without internet
				Console.WriteLine(ex);
				_feeds.Add(new FeedObject() { Title = "Test", Date = "January 2099", Link = "www.example.com" });
				PopulateList();
				return;
			}
			foreach (var item in rssFeeds.Items)
			{
				var feed = new FeedObject()
				{
					Title = item.Title,
					Date = item.PublishingDate.Value.ToString("y"),
					Link = item.Link
				};
				_feeds.Add(feed);
			}
			PopulateList();
		}
		private void PopulateList()
		{
			_listView.HasUnevenRows = true;

			DataTemplate template = new DataTemplate(typeof(CustomCell));
			_listView.ItemTemplate = template;

			_listView.ItemsSource = _feeds;

			Content = _listView;
		}

		private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			// To prevent opening multiple pages on double tapping
			_listView.IsEnabled = false;
			var item = e.SelectedItem as FeedObject;
			if (item != null)
				await Navigation.PushAsync(new StreamDetailsPage(item));
			((Xamarin.Forms.ListView)sender).SelectedItem = null;

			_listView.IsEnabled = true;

		}
		#endregion Private Functions & Event Handlers

		#region LifeCycle Event Overrides
		protected override void OnAppearing()
		{
			base.OnAppearing();
			PullData();
		}
		#endregion LifeCycle Event Overrides
	}
}
