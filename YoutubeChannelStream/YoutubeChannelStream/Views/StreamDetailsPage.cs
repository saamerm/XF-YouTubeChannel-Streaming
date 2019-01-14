using System;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace YoutubeChannelStream
{
	public class StreamDetailsPage : ContentPage
	{
		FeedObject _rssFeedObject;

		public StreamDetailsPage(FeedObject feedObject)
		{
			Title = feedObject.Title;
			_rssFeedObject = feedObject;
			// For iPhone X
			On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

			LoadPage();
		}

		private void LoadPage()
		{
			HtmlWebViewSource personHtmlSource = new HtmlWebViewSource();
			var screenWidth = Application.Current.MainPage.Width - 10;

			// According to standard video resolutions
			var playerHeight = screenWidth / 1.5;

			//Cannot place this logic in ViewModel, because Screen Sizes are needed to create iFrame properly
			Uri uri = new Uri(_rssFeedObject.Link);
			string queryString = uri.Query;
			string technology = System.Web.HttpUtility.ParseQueryString(queryString).Get("v");
			string header = "<head> <style> body {background-color: rgb(241, 241, 241);}</style> </head>";
			var videoUrl = "https://www.youtube.com/embed/" + technology;
			personHtmlSource.Html = string.Format("<html>{0}<body><iframe width='{1}' height='{2}' src='{3}' frameborder='0' allow='autoplay; encrypted-media' allowfullscreen></iframe></body></html>",
							      header, screenWidth, playerHeight, videoUrl);

			var webview = new WebView()
			{
				BackgroundColor = Color.DimGray,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			webview.Source = personHtmlSource;

			Label title = new Label
			{
				Text = _rssFeedObject.Title,
				HorizontalOptions = LayoutOptions.Center,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold
			};

			Label date = new Label
			{
				Text = _rssFeedObject.Date,
				FontSize = 12
			};

			var descriptionStack = new StackLayout
			{
				BackgroundColor = Color.FromRgb(241, 241, 241),
				Spacing = 10,
				Padding = 20,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { title, date }
			};

			var pageStack = new StackLayout()
			{
				BackgroundColor = Color.FromRgb(241, 241, 241),
				Spacing = 0,
				Margin = 0,
				Padding = 0,
				Children = { webview, descriptionStack }
			};
			Content = pageStack;
		}
	}
}
