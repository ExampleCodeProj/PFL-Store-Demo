using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PflStoreProject.Infrastructure;
using PflStoreProject.Models;

namespace PflStoreProject.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult CustomerData(Data product)
        {
            var item = new Item
            {
                productID = product.Id,
                quantity = product.QuantityMinimum ?? 1,
            };
            HttpContext.Session.SetJson("Items", item);
            return View("CustomerData");
        }

        [HttpPost]
        public IActionResult CustomerData()
        {
            return View();
        }
    }
}