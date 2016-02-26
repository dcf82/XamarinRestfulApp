using System;

namespace TheNewYorkTimes
{
	public static class Config
	{
		// News Service URLS
		public const string BASE_URL = "http://api.nytimes.com/svc/news/v3/content/all/";
		public const string NEWS = "all.json?api-key=733afc6ddff242156ee645286cdb394b:2:74102822" +
			"&limit={0}&offset={1}";
	}
}
