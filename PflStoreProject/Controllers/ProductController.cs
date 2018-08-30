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
                string response = _client.GetProducts().Result;
                JObject queryableRes = JObject.Parse(response);
                // extract data section and convert to queryable collection
                IList<JToken> results = queryableRes["results"]["data"].Children().ToList();
                List<ProductViewModel> productList = new List<ProductViewModel>();
                // loop throgh the JObject; map to model; add to collection
                foreach (JToken token in results)
                {
                    ProductViewModel product = token.ToObject<ProductViewModel>();
                    productList.Add(product);
                }
                return View(productList);
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

            JObject queryableRes = JObject.Parse(rawResults);
            if (queryableRes["results"]["errors"].Any())
            {
                IList<JToken> errors = queryableRes["results"]["errors"].Children().ToList();
                List<Error> errorsList = new List<Error>();
                foreach (JToken err in errors)
                {
                    Error error = err.ToObject<Error>();
                    errorsList.Add(error);
                }
                return View("Errors", errorsList);
            }
            ProductDetail detail = queryableRes["results"]["data"].ToObject<ProductDetail>();
            ProductDetailViewModel detailModel = new ProductDetailViewModel()
            {
                Detail = detail
            };
            return View(detailModel);

        }
    }
}