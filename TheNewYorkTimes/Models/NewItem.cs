using System;
using Newtonsoft.Json;

namespace TheNewYorkTimes
{
	public class NewItem
	{
		[JsonProperty( "section" )]
		public string Section { get; set; }

		[JsonProperty( "title" )]
		public string Title { get; set; }

		[JsonProperty( "abstract" )]
		public string Abstract { get; set; }

		[JsonProperty( "url" )]
		public string Url { get; set; }

		[JsonProperty( "thumbnail_standard" )]
		public string ThumbnailStandard { get; set; }

		[JsonProperty( "item_type" )]
		public string ItemType { get; set; }

		[JsonProperty( "source" )]
		public string Source { get; set; }

		[JsonProperty( "published_date" )]
		public string PublishedDate { get; set; }
	}
}
