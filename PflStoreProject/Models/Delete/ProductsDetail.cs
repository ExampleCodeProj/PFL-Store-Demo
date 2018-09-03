using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

//ENTIRE PAYLOAD RECEIVED FROM API

namespace PflStoreProject.Models
{
    public class ProductsDetail
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
        [JsonProperty("results")]
        public Results Results { get; set; }
    }
    public class Meta
    {
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("duration")]
        public int Duration { get; set; }
    }
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
        public int? QuantityDefault { get; set; }
        [JsonProperty("quantityMinimum")]
        public int? QuantityMinimum { get; set; }
        [JsonProperty("quantityMaximum")]
        public int? QuantityMaximum { get; set; }
        [JsonProperty("quantityIncrement")]
        public int? QuantityIncrement { get; set; }
        [JsonProperty("shippingMethodDefault")]
        public string ShippingMethodDefault { get; set; }
        [JsonProperty("emailTemplateId")]
        public object EmailTemplateId { get; set; }
        [JsonProperty("hasTemplate")]
        public bool HasTemplate { get; set; }
        [JsonProperty("templateFields")]
        public object TemplateFields { get; set; }
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
