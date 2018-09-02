using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ViewModels
{
	public class BillingVariable
	{
		[JsonProperty("key")]
		public string Key { get; set; }
		[JsonProperty("value")]
		public string Value { get; set; }
	}
	
}