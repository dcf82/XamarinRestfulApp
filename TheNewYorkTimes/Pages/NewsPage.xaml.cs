using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Newtonsoft.Json;

namespace TheNewYorkTimes
{
	public partial class NewsPage : ContentPage
	{
		protected delegate void UpdateNews(News news);
		protected event UpdateNews update;

		private const int MAX_NUM_NEWS = 10;
		private int numItems = 0;
		private RestService service = new RestService();
		private ObservableCollection<NewItem> news = new ObservableCollection<NewItem>();

		public NewsPage ()
		{
			// This is a setting to make my page look autonomous
			NavigationPage.SetHasNavigationBar(this, true);
			NavigationPage.SetHasBackButton (this, false);

			// Page Title
			Title = "The New York Times";

			// Initialize Page
			InitializeComponent ();
			Debug.WriteLine ("Loading Page");

			// Loading Web Service
			LoadWebServiceAsync ();

			// Loading Items Message
			Debug.WriteLine ("Loading New Items");

			// Load the items
			newsLV.ItemsSource = news;

			// Handler
			update = new UpdateNews(AddMoreNews);
		
			// Supporting Lazy Loading Feature
			newsLV.ItemAppearing += (sender, e) => {
				if(isLoading) return;
				int index = news.IndexOf (e.Item as NewItem);
				Debug.WriteLine ("Item Index: " + index);
				if (index == news.Count - 1) {
					LoadWebServiceAsync();
				}
			};

			newsLV.ItemTapped += async (sender, e) => {
				await Navigation.PushAsync(new NewDetails(e.Item as NewItem));
			};
		}

		private bool isLoading;

		// Load the news
		public async void LoadWebServiceAsync ()
		{
			isLoading = true;

			Debug.WriteLine ("Start Index: " + numItems);

			var uri = new Uri (string.Format (Config.BASE_URL + Config.NEWS, MAX_NUM_NEWS, numItems));
			var response = await service.client.GetAsync (uri);

			// Error
			if (!response.IsSuccessStatusCode) {
				Debug.WriteLine ("Error = " + response.Content);
				return;
			}

			var content = await response.Content.ReadAsStringAsync ();
			News newsResponse = JsonConvert.DeserializeObject <News> (content);
			update (newsResponse);
			numItems += newsResponse.Results.Count;
		
			Debug.WriteLine ("Items Got: " + newsResponse.Results.Count);

			isLoading = false;
		}

		protected void AddMoreNews(News news) {
			foreach (NewItem i in news.Results) {
				this.news.Add (i);
			}
		}
	}
}
