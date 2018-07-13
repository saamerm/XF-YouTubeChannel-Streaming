using System;
using YoutubeChannelStream;
using Xamarin.Forms;

namespace YoutubeChannelStream
{
	public class StreamPage : ContentPage
	{
		private RSSViewModel viewModel;
		public StreamPage()
		{
			var label = new Label()
			{
				Text = "YOLO"
			};

			var stack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			stack.Children.Add(label);
			Content = stack;
		}
	}
}
