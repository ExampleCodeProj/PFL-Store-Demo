using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ApiProductDetails
{
	public class DeliveredPrice
	{
		[JsonProperty("deliveryMethodCode")]
		public string DeliveryMethodCode { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("price")]
		public double Price { get; set; }
		[JsonProperty("country")]
		public object Country { get; set; }
		[JsonProperty("countryCode")]
		public object CountryCode { get; set; }
		[JsonProperty("created")]
		public DateTime Created { get; set; }
		[JsonProperty("locationType")]
		public string LocationType { get; set; }
		[JsonProperty("isDefault")]
		public bool IsDefault { get; set; }
	}
	
}