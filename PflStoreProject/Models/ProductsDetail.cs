using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
    }
    public class Results
    {
        [JsonProperty("errors")]
        public List<object> Errors { get; set; }
        [JsonProperty("messages")]
        public List<object> Messages { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
    public class Data
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("hasTemplate")]
        public bool HasTemplate { get; set; }
        [JsonProperty("imageURL")]
        public string ImageURL { get; set; }
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
        [JsonProperty("deliveredPrices")]
        public List<DeliveredPrice> DeliveredPrices { get; set; }
        [JsonProperty("templateFields")]
        public TemplateFields TemplateFields { get; set; }
    }
    public class DeliveredPrice
    {
        [JsonProperty("deliveryMethodCode")]
        public string DeliveryMethodCode { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }
        [JsonProperty("locationType")]
        public string LocationType { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
    public class TemplateFields
    {
        [JsonProperty("fieldlist")]
        public Fieldlist Fieldlist { get; set; }
    }
    public class Fieldlist
    {
        [JsonProperty("field")]
        public List<Field> Field { get; set; }
    }
    public class Field
    {
        [JsonProperty("required")]
        public string Required { get; set; }
        [JsonProperty("visible")]
        public string Visible { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("subtype")]
        public string Subtype { get; set; }
        [JsonProperty("fieldname")]
        public string Fieldname { get; set; }
        [JsonProperty("prompt")]
        public List<Prompt> Prompt { get; set; }
        [JsonProperty("default")]
        public string Default { get; set; }
        [JsonProperty("orgvalue")]
        public string Orgvalue { get; set; }
        [JsonProperty("htmlfieldname")]
        public string Htmlfieldname { get; set; }
    }
    public class Prompt
    {
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
