using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ViewModels
{
	public class CallbackHeaders
	{
		[JsonProperty("header_field_sample1")]
		public string HeaderFieldSample1 { get; set; }
		[JsonProperty("header_field_sample2")]
		public string HeaderFieldSample2 { get; set; }
	}
	
}