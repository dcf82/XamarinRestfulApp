using System;
using System.Diagnostics;

using Xamarin.Forms;

namespace TheNewYorkTimes
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = PageManager.Init ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
			Debug.WriteLine ("App OnStart ()");
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
			Debug.WriteLine ("App OnSleep ()");
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
			Debug.WriteLine ("App OnResume ()");
		}
	}
}

