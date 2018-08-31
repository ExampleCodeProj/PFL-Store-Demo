using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ApiProductDetails
{
	public class ProductionSpeed
	{
		[JsonProperty("days")]
		public int Days { get; set; }
		[JsonProperty("isDefault")]
		public bool IsDefault { get; set; }
	}
	
}