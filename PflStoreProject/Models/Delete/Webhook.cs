using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ViewModels
{
	public class Webhook
	{
		[JsonProperty("id")]
		public object Id { get; set; }
		[JsonProperty("type")]
		public string Type { get; set; }
		[JsonProperty("callbackUri")]
		public string CallbackUri { get; set; }
		[JsonProperty("callbackHeaders")]
		public CallbackHeaders CallbackHeaders { get; set; }
	}
	
}