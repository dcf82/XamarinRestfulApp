using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheNewYorkTimes
{
	public partial class NewDetails : ContentPage
	{
		public NewDetails (NewItem item)
		{
			// This is a setting to make my page look autonomous
			NavigationPage.SetHasNavigationBar(this, true);

			// Init the Page
			InitializeComponent ();

			// Page Title
			Title = item.Title;

			// Load the Browser
			WebBrowser.Source = item.Url;
		}

		private void backClicked(object sender, EventArgs e)
		{
			//check to see if there is anywhere to go back to
			if (WebBrowser.CanGoBack) {
				WebBrowser.GoBack ();
			} else { //if not, leave the view
				Navigation.PopAsync ();
			}
		}

		private void forwardClicked(object sender, EventArgs e)
		{
			if (WebBrowser.CanGoForward) {
				WebBrowser.GoForward ();
			}
		}

		void webOnNavigating (object sender, WebNavigatingEventArgs e)
		{
			LoadingLabel.IsVisible = true;
		}

		void webOnEndNavigating (object sender, WebNavigatedEventArgs e)
		{
			LoadingLabel.IsVisible = false;
		}
	}
}
