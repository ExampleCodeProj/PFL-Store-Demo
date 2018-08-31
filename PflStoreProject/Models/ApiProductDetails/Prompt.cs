using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ApiProductDetails
{
	public class Prompt
	{
		[JsonProperty("language")]
		public string Language { get; set; }
		[JsonProperty("text")]
		public string Text { get; set; }
	}
	
}