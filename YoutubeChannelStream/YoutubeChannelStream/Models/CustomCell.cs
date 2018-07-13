using System;
using Xamarin.Forms;

namespace YoutubeChannelStream
{
	public class CustomCell : ViewCell
	{
		public CustomCell()
		{
			var youTubeFeed = new Label();
			youTubeFeed.LineBreakMode = LineBreakMode.WordWrap;
			youTubeFeed.SetBinding(Label.TextProperty, "Title");
			youTubeFeed.FontSize = 16;
			var youTubeFeed2 = new Label();
			youTubeFeed2.LineBreakMode = LineBreakMode.WordWrap;
			youTubeFeed2.SetBinding(Label.TextProperty, "Date");
			youTubeFeed2.FontSize = 10;

			var verticalStack = new StackLayout();
			verticalStack.Children.Add(youTubeFeed);
			verticalStack.Children.Add(youTubeFeed2);

			var image = new Image()
			{
				Source = "youtube.png",
				HeightRequest = 50,
				MinimumWidthRequest = 70
			};
			var horizontalStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = {image, verticalStack},
				MinimumHeightRequest = 100,
				Padding = 10,
				Margin = 5
			};

			View = horizontalStack;
		}
	}
}
