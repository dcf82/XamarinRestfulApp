using System;
using Xamarin.Forms;

namespace TheNewYorkTimes
{
	public class PageManager
	{
		public static NavigationPage Init()
		{
			return new NavigationPage(new NewsPage());
		}
	}
}
