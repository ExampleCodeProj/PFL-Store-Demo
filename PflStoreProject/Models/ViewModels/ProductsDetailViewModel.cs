// PRODUCT DETAILS TO SEND TO VIEW 
// ITEM PROPERTIES TO GET BACK FROM

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PflStoreProject.Models.ViewModels;

namespace PflStoreProject.Models.ViewModels
{
    public class ProductDetailViewModel
    {
        
        public ProductDetail Detail { get; set; }

        public Item Item { get; set; }

        [Required(ErrorMessage = "Please select a shipping method.")]
        public string DeliveryMethod { get; set; }

        [Required(ErrorMessage= "Please select an option.")]
        public string DesignOption { get; set; }

        public IEnumerable<string> Countries { get; set; }

    }


}
