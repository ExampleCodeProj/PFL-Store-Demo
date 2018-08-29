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
           
            
            Task<ProductsDetail> rawResults = _client.GetProductById(id);
            //TODO: clean; this is the only object that include root object
            if (rawResults.Result.Meta.StatusCode != 200)
            {
                var errors = rawResults.Result.Results.Errors;
                List<Error> errorList = new List<Error>();
                foreach (JToken item in errors)
                {
                    Error error = item.ToObject<Error>();
                    errorList.Add(error);
                }
                return View("Errors", errorList);
            }
            var productDetail = rawResults.Result.Results.Data;
            return View(productDetail);

            


        }




    }
}