using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TheNewYorkTimes
{
	public class News
	{
		[JsonProperty("num_results")]
		public int NumResults { get; set;}

		[JsonProperty("results")]
		public List<NewItem> Results { get; set;}
	}
}
