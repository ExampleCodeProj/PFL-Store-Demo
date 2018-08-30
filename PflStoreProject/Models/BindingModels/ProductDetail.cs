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
        public object Sku { get; set; }
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
        // public object TemplateFields { get; set; }
        // public DateTime LastUpdated { get; set; }
        // public List<object> CustomValues { get; set; }
        public List<DeliveredPrice> DeliveredPrices { get; set; }
        public List<ProductionSpeed> ProductionSpeeds { get; set; }
        public string ProductFormat { get; set; }
        public object ProductRestrictionType { get; set; }

    }


}