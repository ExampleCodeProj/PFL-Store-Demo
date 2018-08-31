using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json.Linq;
using PflStoreProject.Infrastructure;
using PflStoreProject.Models;
using PflStoreProject.Models.ViewModels;
using PflStoreProject.Services;
using Data = PflStoreProject.Models.Data;

using OrderCustomer = PflStoreProject.Models.OrderCustomer;
using Shipment = PflStoreProject.Models.Shipment;

namespace PflStoreProject.Controllers
{
    public class OrderController : Controller
    {
        private HttpClientService _client;
        public OrderController(HttpClientService client)
        {
            _client = client;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(ProductDetailViewModel itemOrdered, IFormFile fileUpload)
        {
            if (itemOrdered.DesignOption == "designFile")
            {
                // TODO: Process File to Blob storage and return name; currently  Item.ItemFile is a temp name of local storage
                string filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                await fileUpload.CopyToAsync(stream);
//                TODO: this should be set to final location
                itemOrdered.Item.ItemFile = filePath;
            }
            if(itemOrdered.DesignOption == "") { }

            // TODO: add validation -- min/max and increment for quantity
            
            //TODO: validate fileItem OR Template data depending on designMethod selected
            
            List<Item> items = HttpContext.Session.GetJson<List<Item>>("Items") ?? new List<Item>();
            HttpContext.Session.SetString("ShippingMethod", itemOrdered.DeliveryMethod);
            itemOrdered.Item.ItemSequenceNumber = items.Count() + 1;
            items.Add(itemOrdered.Item);
            HttpContext.Session.SetJson("Items", items);
            return RedirectToAction("ShipmentData");
            

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
            return RedirectToAction("SubmitOrder");
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
            string shippingMetod = HttpContext.Session.GetString("ShippingMethod");
            
            shipData.ShippingMethod = shippingMetod;
            HttpContext.Session.SetJson("Shipment", shipData);
            return RedirectToAction("CustomerData");
        }


        public async Task<IActionResult> SubmitOrder()
        {
            //            TODO: handle errors
            OrderCustomer custData = HttpContext.Session.GetJson<OrderCustomer>("CustData");
            List<Item> itemsList = HttpContext.Session.GetJson<List<Item>>("Items");
     

            var shipment = HttpContext.Session.GetJson<Shipment>("Shipment");
            
            var shipmentsList = new List<Shipment>();
            shipmentsList.Add(shipment);

            Order order = new Order()
            {
                orderCustomer = custData,
                items = itemsList,
                shipments = shipmentsList,
            };
            try
            {
                JObject response = await _client.SubmitOrder(order);
                if (response["results"]["errors"].Any())
                {
                    IList<JToken> errors = response["results"]["errors"].Children().ToList();
                    List<Error> errorsList = new List<Error>();
                    foreach (JToken err in errors)
                    {
                        Error error = err.ToObject<Error>();
                        errorsList.Add(error);
                    }

                    return View("Errors", errorsList);
                    //TODO: product specific error needs to remove item from list or update
                }

                NewOrderPayload results = response["results"]["data"].ToObject<NewOrderPayload>();
                return View("OrderConfirmation", results);
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
    }
}