using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace TheNewYorkTimes
{
	public class NewsVM : INotifyPropertyChanged
	{
		public delegate void UpdateComputedEventHandler(PropertyChangedEventArgs args);
		private event UpdateComputedEventHandler UpdateData;

		public event PropertyChangedEventHandler PropertyChanged;

		// Base Constructor
		public NewsVM ()
		{
			Debug.WriteLine ("Constructor of NewsVM ()");
			PropertyChanged += (object sender, PropertyChangedEventArgs args) => {
				if (UpdateData != null) {
					UpdateData(args);
				}
			};
		}

		// Property Changed Notification
		protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
		{
			Debug.WriteLine ("Property Changed: " + propertyName);
			if (PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
