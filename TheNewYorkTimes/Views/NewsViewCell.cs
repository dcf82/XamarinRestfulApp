using System;
using Xamarin.Forms;

namespace TheNewYorkTimes
{
	public class NewsViewCell : ViewCell
	{
		public NewsViewCell ()
		{
			View = new NewsItemView ();

			if (Device.OS == TargetPlatform.iOS) {
				Height = 150;
			}
		}
	}
}
