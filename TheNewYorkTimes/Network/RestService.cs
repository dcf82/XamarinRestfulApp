using System;
using System.Net.Http;

namespace TheNewYorkTimes
{
	public class RestService
	{
		public HttpClient client;

		public RestService ()
		{
			client = new HttpClient ();
			client.MaxResponseContentBufferSize = 256000;
		}
	}
}

