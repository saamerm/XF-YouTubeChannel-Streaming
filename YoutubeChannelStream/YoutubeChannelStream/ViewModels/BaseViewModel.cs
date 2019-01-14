using System;
using System.ComponentModel;

namespace YoutubeChannelStream
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		private bool _isBusy;
		/// <summary>
		/// Gets or sets if VM is busy working
		/// </summary>
		public bool IsBusy
		{
			get { return _isBusy; }
			set { _isBusy = value; OnPropertyChanged("IsBusy"); }
		}

		//INotifyPropertyChanged Implementation
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
