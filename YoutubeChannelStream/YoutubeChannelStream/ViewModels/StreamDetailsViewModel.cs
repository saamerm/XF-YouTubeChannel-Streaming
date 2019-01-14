using System;
namespace YoutubeChannelStream
{
	public class StreamDetailsViewModel
	{
		#region Properties
		/// <summary>
		/// Gets or sets the title of the stream details.
		/// </summary>
		/// <value>The title.</value>
		public string Title { protected get; set; }

		/// <summary>
		/// Gets or sets the link of the stream details.
		/// </summary>
		/// <value>The link.</value>
		public string Link { protected get; set; }

		/// <summary>
		/// Gets or sets the date of the stream details.
		/// </summary>
		/// <value>The date.</value>
		public string Date { protected get; set; }
		#endregion Properties

		public StreamDetailsViewModel(FeedObject feedObject)
		{
			Title = feedObject.Title;
			Link = feedObject.Link;
			Date = feedObject.Date;
		}
	}
}
