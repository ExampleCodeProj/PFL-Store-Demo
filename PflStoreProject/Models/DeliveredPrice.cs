using System;
using Newtonsoft.Json;

//ENTIRE PAYLOAD RECEIVED FROM API

namespace PflStoreProject.Models
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
        public string Country { get; set; }
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("locationType")]
        public string LocationType { get; set; }
        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }
    }

}
