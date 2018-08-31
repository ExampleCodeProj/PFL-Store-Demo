// PRODUCT DETAILS TO SEND TO VIEW 
// ITEM PROPERTIES TO GET BACK FROM

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PflStoreProject.Models.BindingModels;
using PflStoreProject.Models.ViewModels;

namespace PflStoreProject.Models.ViewModels
{
    public class ProductDetailViewModel
    {
        
        public ProductDetail Detail { get; set; }

        public Item Item { get; set; }

        public string DeliveryMethod { get; set; }
        public string DesignOption { get; set; }
        public IEnumerable<string> Countries { get; set; }

    }


}
