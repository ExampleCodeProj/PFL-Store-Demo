using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PflStoreProject.Models;

namespace PflStoreProject.Components
{
    public class ProductNavViewComponent : ViewComponent
    {
        private HttpClientService _client = new HttpClientService();
 

        public IViewComponentResult Invoke()

        {
            var products = _client.GetProducts();
            return View(products.Result);
        }
    }
}
