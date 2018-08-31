using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ApiProductDetails
{
	public class Item
	{
		[JsonProperty("prompt")]
		public Prompt Prompt { get; set; }
		[JsonProperty("value")]
		public string Value { get; set; }
	}
	
}