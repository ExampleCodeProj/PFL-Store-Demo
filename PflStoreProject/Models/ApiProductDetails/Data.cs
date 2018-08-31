using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ApiProductDetails
{
	public class Data
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("sku")]
		public object Sku { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("imageURL")]
		public string ImageURL { get; set; }
		[JsonProperty("images")]
		public List<object> Images { get; set; }
		[JsonProperty("files")]
		public List<object> Files { get; set; }
		[JsonProperty("quantityDefault")]
		public int QuantityDefault { get; set; }
		[JsonProperty("quantityMinimum")]
		public int QuantityMinimum { get; set; }
		[JsonProperty("quantityMaximum")]
		public object QuantityMaximum { get; set; }
		[JsonProperty("quantityIncrement")]
		public object QuantityIncrement { get; set; }
		[JsonProperty("shippingMethodDefault")]
		public string ShippingMethodDefault { get; set; }
		[JsonProperty("emailTemplateId")]
		public object EmailTemplateId { get; set; }
		[JsonProperty("hasTemplate")]
		public bool HasTemplate { get; set; }
		[JsonProperty("templateFields")]
		public TemplateFields TemplateFields { get; set; }
		[JsonProperty("lastUpdated")]
		public DateTime LastUpdated { get; set; }
		[JsonProperty("customValues")]
		public List<object> CustomValues { get; set; }
		[JsonProperty("deliveredPrices")]
		public List<DeliveredPrice> DeliveredPrices { get; set; }
		[JsonProperty("productionSpeeds")]
		public List<ProductionSpeed> ProductionSpeeds { get; set; }
		[JsonProperty("productFormat")]
		public string ProductFormat { get; set; }
		[JsonProperty("productRestrictionType")]
		public object ProductRestrictionType { get; set; }
	}
	
}