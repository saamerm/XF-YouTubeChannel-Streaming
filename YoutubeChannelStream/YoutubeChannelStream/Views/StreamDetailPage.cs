using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace YoutubeChannelStream
{
	public class StreamDetailPage : ContentPage
	{
		public StreamDetailPage(RSSFeedObject feedObject)
		{
			Title = feedObject.Title;

			// For iPhone X
			On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

			HtmlWebViewSource personHtmlSource = new HtmlWebViewSource();
			//personHtmlSource.SetBinding(HtmlWebViewSource.HtmlProperty, "HTMLDesc");
			//personHtmlSource.Html = @"<html><body>  <div style=' position: relative; padding-bottom: 56.25%; padding-top: 25px;'> <iframe style='position: absolute; top: 0; left: 0; width: 100%; height: 100%;'  src='https://www.youtube.com/embed/bVdfj7HXuXE' frameborder='0' allowfullscreen></iframe></div> </body></html>";
			//"'"
			personHtmlSource.Html = @"<html>a<body>a  <div style=' position: relative; padding-bottom: 56.25%; padding-top: 25px;'> <iframe width='560' height='315' src='https://www.youtube.com/embed/DHHY8m3rEzU' frameborder='0' allow='autoplay; encrypted-media' allowfullscreen></iframe></div> </body></html>";
			var htmlSource = new HtmlWebViewSource();
			htmlSource.Html = @"<html><body>
			  <h1>Xamarin.Forms</h1>
			  <p>Welcome to WebView.</p>
			  </body></html>";
			var browser = new WebView();
			browser.Source = htmlSource;

			Label title = new Label
			{
				Text = feedObject.Title,
				HorizontalOptions = LayoutOptions.Center,
				FontSize = 20,
				TextColor = Color.Purple,
				FontAttributes = FontAttributes.Bold
			};

			Label date = new Label 
			{ 
				Text = feedObject.Date,
				FontSize = 16
			};

			var stack = new StackLayout
			{
				Spacing = 10,
				Padding = 20,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = { browser, title, date }
			};
			Content = stack;
		}
	}
}
