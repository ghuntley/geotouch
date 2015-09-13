using System;

//[
//	{
//		"id": 4243144,
//		"title": "Space Water",
//		"userName": "COLOURlover",
//		"numViews": 71,
//		"numVotes": 2,
//		"numComments": 0,
//		"numHearts": 0,
//		"rank": 0,
//		"dateCreated": "2011-09-01 00:11:26",
//		"hex": "248AA1",
//		"rgb": {
//			"red": 36,
//			"green": 138,
//			"blue": 161
//		},
//		"hsv": {
//			"hue": 191,
//			"saturation": 78,
//			"value": 63
//		},
//		"description": "",
//		"url": "http://www.colourlovers.com/color/248AA1/Space_Water",
//		"imageUrl": "http://www.colourlovers.com/img/248AA1/100/100/Space_Water.png",
//		"badgeUrl": "http://www.colourlovers.com/images/badges/c/4243/4243144_Space_Water.png",
//		"apiUrl": "http://www.colourlovers.com/api/color/248AA1"
//	}
//]

namespace ColourLovers.ServiceModel
{
	public class RGB
	{
		public int red { get; set; }
		public int green { get; set; }
		public int blue { get; set; }
	}

	public class HSV
	{
		public int hue { get; set; }
		public int saturation { get; set; }
		public int value { get; set; }
	}

	// Unfortunately the API uses american spelling of "Colors" as the API method name.
	public class Colors
	{
		public int id { get; set; }
		public string title { get; set; }
		public string userName { get; set; }
		public int numViews { get; set; }
		public int numVotes { get; set; }
		public int numComments { get; set; }
		public int numHearts { get; set; }
		public int rank { get; set; }
		public DateTimeOffset dateCreated { get; set; }
		public string hex { get; set; }
		public RGB rgb { get; set; }
		public HSV hsv { get; set; }
		public string description { get; set; }
		public string url { get; set; }
		public string imageUrl { get; set; }
		public string badgeUrl { get; set; }
		public string apiUrl { get; set; }
	}
}

