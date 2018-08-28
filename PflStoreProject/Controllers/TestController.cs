using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PflStoreProject.Infrastructure;
using PflStoreProject.Models;
using System.IO;
using PflStoreProject.Models.ViewModels;

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
