using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ApiProductDetails
{
	public class RootObject
	{
		[JsonProperty("meta")]
		public Meta Meta { get; set; }
		[JsonProperty("results")]
		public Results Results { get; set; }
	}
	
}