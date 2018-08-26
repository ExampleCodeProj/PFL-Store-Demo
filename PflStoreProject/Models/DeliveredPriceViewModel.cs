using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PflStoreProject.Models
{
    public class DeliveredPrice
    {
        public string DeliveryMothodCode { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string LocationType { get; set; }
        public decimal Price { get; set; }
        public bool IsDefault { get; set; }
    }
}
