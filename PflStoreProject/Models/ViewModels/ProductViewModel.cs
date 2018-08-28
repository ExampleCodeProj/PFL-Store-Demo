using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PflStoreProject.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool HasTemplate { get; set; }
        public int QuantityDefault { get; set; }
        public int? QuantityIncrement { get; set; }
        public int? QuantityMaximum { get; set; }
        public int? QuantityMinimum { get; set; }
        public string ShippingMethodDefault { get; set; }
        public IEnumerable<DeliveredPrice> DeliveredPrices { get; set; }
    }
}
