using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ApiProductDetails
{
	public class Results
	{
		[JsonProperty("errors")]
		public List<object> Errors { get; set; }
		[JsonProperty("messages")]
		public List<object> Messages { get; set; }
		[JsonProperty("data")]
		public Data Data { get; set; }
	}
	
}