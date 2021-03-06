﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PflStoreProject.Models;
using PflStoreProject.Services;

namespace PflStoreProject.Components
{
//    ideally, this would extract distinct categories from product list to use as filtered navigation 
//    currently lists all products as not suitable property to filter by
    
    public class ProductNavViewComponent : ViewComponent
    {
        private HttpClientService _client;

        public ProductNavViewComponent(HttpClientService client)
        {
            _client = client;
        }

        public IViewComponentResult Invoke()
        {
            var responseProducts = _client.GetProducts();
            string response = _client.GetProducts().Result;
            JObject queryableRes = JObject.Parse(response);
            IList<JToken> results = queryableRes["results"]["data"].Children().ToList();
            List<ProductViewModel> productList = new List<ProductViewModel>();
            foreach (JToken token in results)
            {
                ProductViewModel product = token.ToObject<ProductViewModel>();
            }
            return View(productList);
        }
    }
}
