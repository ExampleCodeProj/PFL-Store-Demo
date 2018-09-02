using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PflStoreProject.Models.ViewModels;

namespace PflStoreProject.Models.BindingModels
{
    public class ProductDetail
    {
        public int Id { get; set; }
//        public object Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        // public List<object> Images { get; set; }
        // public List<object> Files { get; set; }
        public int QuantityDefault { get; set; } = 1;
        public int? QuantityMinimum { get; set; } = 1;
        public int? QuantityMaximum { get; set; }
        public int? QuantityIncrement { get; set; } = 1;
        public string ShippingMethodDefault { get; set; }
        // public object EmailTemplateId { get; set; }
        public bool HasTemplate { get; set; }
        public TemplateFields TemplateFields { get; set; }
        // public DateTime LastUpdated { get; set; }
        // public List<object> CustomValues { get; set; }
        public List<DeliveredPrice> DeliveredPrices { get; set; }
        public List<ProductionSpeed> ProductionSpeeds { get; set; }
//        public string ProductFormat { get; set; }
//        public object ProductRestrictionType { get; set; }
    }

    public class TemplateFields
    {
        public Fieldlist Fieldlist { get; set; }
    }

    public class Fieldlist
    {
        public List<Field> Field { get; set; }
    }
    public class Field
    {
        public string Required { get; set; }
        public string Visible { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string Autosort { get; set; }
        public string Fieldname { get; set; }
        public List<Prompt> Prompt { get; set; }
        public string Default { get; set; }
        public string Orgvalue { get; set; }
        public string Htmlfieldname { get; set; }
//        public Picklist Picklist { get; set; }
    }
    public class Prompt
    {
        public string Language { get; set; }
        public string Text { get; set; }
    }
//    public class Picklist
//    {
//        public List<Item> Item { get; set; }
//    }
    public class Item
    {
        public Prompt Prompt { get; set; }
        public string Value { get; set; }
    }
}