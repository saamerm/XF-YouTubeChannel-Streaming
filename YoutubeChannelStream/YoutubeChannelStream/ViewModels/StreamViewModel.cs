using System;
using System.Collections.Generic;
using System.Windows.Input;
using CodeHollow.FeedReader;
using Xamarin.Forms;

namespace YoutubeChannelStream
{
	public class StreamViewModel : BaseViewModel
	{
		string url, title;
		IList<StreamDetailsViewModel> items;
		bool isRefreshing;

		public StreamViewModel()
		{
			RefreshCommand = new Command(
			    execute: () =>
			    {
				    PullData(url);
			    },
			    canExecute: () =>
			    {
				    return !IsRefreshing;
			    });
		}

		public string Url
		{
			set
			{ 
				if (SetProperty(ref url, value) && !String.IsNullOrEmpty(url))
				{
					PullData(url);
				}
			}
			get
			{
				return url;
			}
		}
		public string Title
		{
			set { SetProperty(ref title, value); }
			get { return title; }
		}

		public IList<StreamDetailsViewModel> Items
		{
			set { SetProperty(ref items, value); }
			get { return items; }
		}

		public ICommand RefreshCommand { private set; get; }

		public bool IsRefreshing
		{
			set { SetProperty(ref isRefreshing, value); }
			get { return isRefreshing; }
		}

		public async void PullData(string url)
		{
			isRefreshing = true;
			var rssFeeds = new Feed();
			try
			{
				rssFeeds = await FeedReader.ReadAsync(url); //("https://www.youtube.com/feeds/videos.xml?channel_id=UCwCOn0lguoGNEIwLgRpoPYw");
			}
			catch (Exception ex)
			{
				// Default values so to test and develop the first screen even without internet
				Console.WriteLine(ex);
				Items.Add(new StreamDetailsViewModel
					  (new FeedObject()
					  {
						  Title = "Test",
						  Date = "January 2099",
						  Link = "www.example.com"
					  }));
				return;
			}
			foreach (var item in rssFeeds.Items)
			{
				var detailsVM = new StreamDetailsViewModel(new FeedObject()
				{
					Title = item.Title,
					Date = item.PublishingDate.Value.ToString("y"),
					Link = item.Link
				});
				Items.Add(detailsVM);
			}
			// Set IsRefreshing to false to stop the 'wait' icon.
			IsRefreshing = false;
		}

	}
}
