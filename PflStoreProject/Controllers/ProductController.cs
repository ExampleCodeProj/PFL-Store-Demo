using System;
using System.Collections;
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
using PflStoreProject.Models.BindingModels;
using PflStoreProject.Models.ViewModels;

namespace PflStoreProject.Controllers
{
    public class ProductController : Controller
    {
        // TODO: pass in through DI
        private HttpClientService _client = new HttpClientService();


        public IActionResult Index()
        {
            try
            {
                List<ProductViewModel> products = _client.GetProducts().Result;
                return View(products);
            }
            catch (HttpRequestException e)
            {
                IDictionary msg = e.Data;
                return View("BadRequest", msg);
            }
            catch (AggregateException e)
            {
                IDictionary msg = e.Data;
                return View("BadRequest", msg);
            }

        }


        public IActionResult Show(string id)
        {
            string rawResults = _client.GetProductById(id).Result;
            JObject queryable = JObject.Parse(rawResults);
            ProductDetail detail = queryable["results"]["data"].ToObject<ProductDetail>();
            ProductDetailViewModel detailModel = new ProductDetailViewModel()
            {
                Detail = detail
            };
            return View(detailModel);

        }
    }
}