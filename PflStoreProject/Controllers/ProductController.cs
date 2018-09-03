using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PflStoreProject.Models;
using PflStoreProject.Models.ViewModels;
using PflStoreProject.Services;

namespace PflStoreProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClientService _client;

        public ProductController(HttpClientService client)
        {
            _client = client;
        }


        public IActionResult Index()
        {
            try
            {
                string response = _client.GetProducts().Result;
                JObject queryableResponse = JObject.Parse(response);
//                extract 'data' section from result and convert to queryable collection
                IList<JToken> results = queryableResponse["results"]["data"].Children().ToList();
                List<ProductViewModel> productList = new List<ProductViewModel>();
//                loop throgh the JObject; map to view model; add to collection
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


        [HttpGet]
        public IActionResult Show(string id)
        {
            string response = _client.GetProductById(id).Result;
            JObject queryableResponse = JObject.Parse(response);
            if (queryableResponse["results"]["errors"].Any())
            {
                IList<JToken> errors = queryableResponse["results"]["errors"].Children().ToList();
                List<Error> errorsList = new List<Error>();
                foreach (JToken err in errors)
                {
                    Error error = err.ToObject<Error>();
                    errorsList.Add(error);
                }
                
                return View("Errors", errorsList);
            }
//            set country property values to be used in UI shipping methods select control
            IList<JToken> deliveredPricesTokens = queryableResponse.SelectTokens("$.results.data.deliveredPrices").ToList();
            List<DeliveredPrice> deliveredPriceList = new List<DeliveredPrice>();
            foreach (JToken item in deliveredPricesTokens[0])
            {
                DeliveredPrice deliveredPrice = item.ToObject<DeliveredPrice>();
                if (deliveredPrice.LocationType == "domestic")
                {
                    deliveredPrice.Country = "USA";
                }
                else
                {
                    deliveredPrice.Country = deliveredPrice.Country ?? "Other";
                }
                deliveredPriceList.Add(deliveredPrice);
            }
            IEnumerable<string> countries = deliveredPriceList.Select(p => p.Country).Distinct();
//            set values of ProductDetailViewModel properties
            ProductDetail productDetail = queryableResponse["results"]["data"].ToObject<ProductDetail>();
            productDetail.DeliveredPrices = deliveredPriceList;
            ProductDetailViewModel detailModel = new ProductDetailViewModel
            {
                Detail = productDetail,
                Countries = countries
            };
            return View(detailModel);
        }
    }
}