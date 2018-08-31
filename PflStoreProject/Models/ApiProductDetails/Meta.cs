using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ApiProductDetails
{
	public class Meta
	{
		[JsonProperty("time")]
		public string Time { get; set; }
		[JsonProperty("statusCode")]
		public int StatusCode { get; set; }
		[JsonProperty("duration")]
		public int Duration { get; set; }
	}
	
}