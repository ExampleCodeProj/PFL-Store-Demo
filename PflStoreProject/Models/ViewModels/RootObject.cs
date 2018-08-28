using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ViewModels
{
	public class RootObject
	{
		[JsonProperty("meta")]
		public Meta Meta { get; set; }
		[JsonProperty("results")]
		public Results Results { get; set; }
	}
	
}