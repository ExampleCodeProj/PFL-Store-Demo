using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json.Linq;
using PflStoreProject.Infrastructure;
using PflStoreProject.Models;

namespace PflStoreProject.Controllers
{
    public class OrderController : Controller
    {
        private HttpClientService _client = new HttpClientService();

        [HttpPost]
        public IActionResult CreateOrderItem(Data item)
        {
            //TODO: add quantity input control to order
            //TODO: add validation
            var newItem = new Item()
            {
                ProductID = item.Id,
                ProductionDays  = item.ProductionSpeeds[0].Days,
                Quantity = item.QuantityMinimum ?? 1
            };
            HttpContext.Session.SetJson("Items", newItem);
            return RedirectToAction("CustomerData");
        }

        [HttpGet]
        public IActionResult CustomerData()
        {
            return View("CustomerData");
        }

        [HttpPost]
        public IActionResult CustomerData(OrderCustomerDataViewModel custData)
        {
            //TODO: add validation
//            TODO: handle errors
            HttpContext.Session.SetJson("CustData", custData);
            return RedirectToAction("ShipmentData");
        }

        [HttpGet]
        public IActionResult ShipmentData()
        {
            return View("ShipmentData");
        }

        [HttpPost]
        public IActionResult ShipmentData(ShipmentDataViewModel shipData)
        {
            //            TODO: add validation
            //            TODO: handle errors
            HttpContext.Session.SetJson("Shipment", shipData);
            return RedirectToAction("SubmitOrder");
        }

//        public IActionResult SubmitOrder()
        public async Task<IActionResult> SubmitOrder()
        {
            //            TODO: handle errors
            var custData = HttpContext.Session.GetJson<OrderCustomer>("CustData");
            var item = HttpContext.Session.GetJson<Item>("Items");
            var itemList = new List<Item>();
            itemList.Add(item);

            var shipment = HttpContext.Session.GetJson<Shipment>("Shipment");
            var shipmentsList = new List<Shipment>();
            shipmentsList.Add(shipment);

            Order order = new Order()
            {
                orderCustomer = custData,
                items = itemList,
                shipments = shipmentsList,
            };
            JObject response = await _client.SubmitOrder(order);
            NewOrderPayload results = response["results"]["data"].ToObject<NewOrderPayload>();

            return View("OrderConfirmation", results);
           
        }



    }
}