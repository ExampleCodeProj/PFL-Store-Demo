using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PflStoreProject.Models;

namespace PflStoreProject.Controllers
{
    public class ProductController : Controller
    {
        // TODO: pass in through DI
        private HttpClientService _client = new HttpClientService();


        public IActionResult Index()
        {
            List<ProductViewModel> products = _client.GetProducts().Result;
            return View(products);
        }


        public IActionResult Show(string id)
        {
            var rawResults = _client.GetProductById(id);
            //TODO: check for errors
            var productDetail = rawResults.Result.Results.Data;
            
            return View(productDetail);
        }




    }
}