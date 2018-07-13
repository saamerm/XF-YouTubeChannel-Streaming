using System;
using YoutubeChannelStream;
using Xamarin.Forms;
using CodeHollow.FeedReader;
using System.Collections.Generic;

namespace YoutubeChannelStream
{
	public class StreamPage : ContentPage
	{
		#region Fields
		ListView _listView = new ListView();
		List<RSSFeedObject> _feeds = new List<RSSFeedObject>();
		#endregion

		#region Constructor
		public StreamPage()
		{
			Title = "Youtube Channel Stream";
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
		private void PopulateList()
		{
			_listView.HasUnevenRows = true;
			_listView.ItemSelected += listView_ItemSelected;

			DataTemplate template = new DataTemplate(typeof(CustomCell));
			_listView.ItemTemplate = template;

			_listView.ItemsSource = _feeds;

			Content = _listView;
		}

		private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as RSSFeedObject;
			//Navigation.PushAsync(new JokeDetail(item));
		}
		#endregion Private Functions & Event Handlers

		#region LifeCycle Event Overrides
		protected async override void OnAppearing()
		{
			base.OnAppearing();
			var rssFeeds = await FeedReader.ReadAsync("https://www.youtube.com/feeds/videos.xml?channel_id=UCwCOn0lguoGNEIwLgRpoPYw");
			foreach (var item in rssFeeds.Items)
			{
				var feed = new RSSFeedObject()
				{
					Title = item.Title,
					Date = item.PublishingDate.Value.ToString("y"),
					Link = item.Link
				};
				_feeds.Add(feed);
			}
			PopulateList();
		}
		#endregion LifeCycle Event Overrides
	}
}
