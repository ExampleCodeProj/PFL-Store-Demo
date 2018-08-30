using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PflStoreProject.Infrastructure;
using PflStoreProject.Models;
using PflStoreProject.Models.BindingModels;
using System.IO;
using PflStoreProject.Models.ViewModels;
using Newtonsoft.Json;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PflStoreProject.Controllers
{
    public class TestController : Controller
    {

        //TEST FOR GETTING RAW JSON DATA

        //        public async Task<IActionResult> Show()
        //        {
        //            var productDetails = await _client.GetProductById("9885");
        //            return Json(productDetails);
        //        }
        public IActionResult Index()
        {
            string path = @"C:\Users\bethh\source\repos\PflStoreProject\PflStoreProject\SampleData\products.json";
            // read all content to buffer and save as a string
            string textAsStr = System.IO.File.ReadAllText(path);
            // parse/interpret the string to a JObject for Linq querying


// =======================================================================================
            JObject queryable = JObject.Parse(textAsStr);
            if (queryable["results"]["errors"].Count() > 1)
            {
                IList<JToken> errors = queryable["results"]["errors"].Children().ToList();
                List<Error> errorsList = new List<Error>();
                foreach (JToken err in errors)
                {
                    Error error = err.ToObject<Error>();
                    errorsList.Add(error);
                }
                return View("Errors", errorsList);
            }
            else
            {
                // extract the 'data' object and set to list to deserialize as collection
                IList<JToken> results = queryable["results"]["data"].Children().ToList();
                List<ProductViewModel> productList = new List<ProductViewModel>();
                foreach(JToken token in results)
                {
                    ProductViewModel product = token.ToObject<ProductViewModel>();
                    productList.Add(product);
                }
                return View(productList);
            }

        }



// ====================================================
//                 SHOW
// =====================================================



            public IActionResult Show(string id)
                {
                string path = @"C:\Users\bethh\source\repos\PflStoreProject\PflStoreProject\SampleData\productDetail.json";
                    // read all content to buffer and save as a string
                    string textAsStr = System.IO.File.ReadAllText(path);
                    // interpret the ENTIRE string as a Json object that can be mapped to csharp

                    // ===============================================================================
            JObject queryable = JObject.Parse(textAsStr);
            if (queryable["results"]["errors"].Count() > 1)
            {
                IList<JToken> errors = queryable["results"]["errors"].Children().ToList();
                List<Error> errorsList = new List<Error>();
                foreach (JToken err in errors)
                {
                    Error error = err.ToObject<Error>();
                    errorsList.Add(error);
                }
                return View("Errors", errorsList);
            }
            else
            {
                // extract the 'data' object and set to list to deserialize as collection
               ProductDetailViewModel results = queryable["results"]["data"].ToObject<ProductDetailViewModel>();

                return View(results);
                    
            }}       
                    
                    // ProductsDetail rawResults = JsonConvert.DeserializeObject<ProductsDetail>(textAsStr);

                    // if (rawResults.Meta.StatusCode != 200)
                    // {
                    //     var errors = rawResults.Results.Errors;
                    //     List<Error> errorList = new List<Error>();
                    //     foreach (JToken item in errors)
                    //     {
                    //         Error error = item.ToObject<Error>();
                    //         errorList.Add(error);
                    //     }
                    //     return View("Errors", errorList);
                    // }
                    // var productDetail = rawResults.Results.Data;
                    // ProductDetailViewModel modelData = new ProductDetailViewModel()
                    // {
                    //     Detail = new ProductDetailot
                        
                        

                    // }
                    // return View(productDetail);
                




        
        public IActionResult OrderSubmit()
        {
            string path = @"C:\Users\bethh\source\repos\PflStoreProject\PflStoreProject\SampleData\BadSubmitOrder.json";
            string textAsStr = System.IO.File.ReadAllText(path);
            JObject queryable = JObject.Parse(textAsStr);
            if (queryable["results"]["errors"].Count() > 1)
            {
                IList<JToken> errors = queryable["results"]["errors"].Children().ToList();
                List<Error> errorsList = new List<Error>();
                foreach (JToken err in errors)
                {
                    Error error = err.ToObject<Error>();
                    errorsList.Add(error);
                }
                return View("Errors", errorsList);
            }
            else
            {

                NewOrderPayload results = queryable["results"]["data"].ToObject<NewOrderPayload>();


                return View("OrderConfirmation", results);

            }

        }


    }

}
//if (queryable["results"]["errors"].Count() > 1)
//{
//IList<JToken> errors = queryable["results"]["errors"].Children().ToList();
//List<Error> errorsList = new List<Error>();
//    foreach (JToken err in errors)
//{
//    Error error = err.ToObject<Error>();
//    errorsList.Add(error);
//}
//return View("Errors", errorsList);
//}
