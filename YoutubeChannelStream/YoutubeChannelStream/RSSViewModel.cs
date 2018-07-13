using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using CodeHollow.FeedReader;

namespace YoutubeChannelStream
{
	public class RSSViewModel : ViewModelBase
	{
		private ObservableCollection<RSSFeedObject> feedItems = new ObservableCollection<RSSFeedObject>();

		/// <summary>
		/// gets or sets the feed items
		/// </summary>
		public ObservableCollection<RSSFeedObject> FeedItems
		{
			get { return feedItems; }
			set { feedItems = value; OnPropertyChanged("FeedItems"); }
		}

		private RSSFeedObject selectedFeedItem;
		/// <summary>
		/// Gets or sets the selected feed item
		/// </summary>
		public RSSFeedObject SelectedFeedItem
		{
			get { return selectedFeedItem; }
			set
			{
				selectedFeedItem = value;
				OnPropertyChanged("SelectedFeedItem");
			}
		}

		private RelayCommand loadItemsCommand;
		/// <summary>
		/// Command to load/refresh items
		/// </summary>
		public ICommand LoadItemsCommand
		{
			get { return loadItemsCommand ?? (loadItemsCommand = new RelayCommand(async () => await ExecuteLoadItemsCommand())); }
		}

		public async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;
			
			IsBusy = true;

			FeedItems.Clear();

			var feeds = await FeedReader.ReadAsync("https://www.youtube.com/feeds/videos.xml?channel_id=UCwCOn0lguoGNEIwLgRpoPYw");

			var list = new List<RSSFeedObject>();
			foreach (var i in items)
			{
				list.Add(new RSSFeedObject() { Date = i.Date.ToString("g"), Title = i.Title, Uri = i.Uri.ToString() });
				Console.WriteLine(string.Format("{0}\t{1}",
					i.Date.ToString("g"),
					i.Title
				));
			}
			//var items = await ParseFeed(responseString);
			//foreach (var item in items)
			//{
			//	item.Image = "logo.png"; //Gravatar.GetUrl(item.Author);
			//	FeedItems.Add(item);
			//}


			IsBusy = false;
		}
	}
}
