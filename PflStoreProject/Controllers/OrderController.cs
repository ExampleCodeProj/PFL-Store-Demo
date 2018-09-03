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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using PflStoreProject.Infrastructure;
using PflStoreProject.Models;
using PflStoreProject.Models.ApiProductDetails;
using PflStoreProject.Models.ViewModels;
using PflStoreProject.Services;
using Data = PflStoreProject.Models.Data;
using Item = PflStoreProject.Models.ViewModels.Item;
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

                //if customer chose template option, capture the data, do validation and save to order item
                if (itemOrdered.DesignOption == "designTemplate")
                {
                    List<TemplateData> templateDataList = new List<TemplateData>();
                    foreach (var field in itemOrdered.Detail.TemplateFields.Fieldlist.Field)
                    {
//                    TODO: add simplied template object into ProductDetailsViewModel
//                    TODO: perform validation on fields
                        TemplateData data = new TemplateData()
                        {
                            TemplateDataName = field.Fieldname,
                            TemplateDataValue = field.Htmlfieldname,
                        };
                        templateDataList.Add(data);
                    }

                    itemOrdered.Item.TemplateData = templateDataList;
                }

                // TODO: add validation -- min/max and increment for quantity
                //Get all items out of session, convert back to ItemList, add new item, save back into session
                //allows for future extensibility to add multiple items -- currently, flow only allows one item per shipment/order
                List<Item> items = HttpContext.Session.GetJson<List<Item>>("Items") ?? new List<Item>();
                HttpContext.Session.SetString("ShippingMethod", itemOrdered.DeliveryMethod);
                itemOrdered.Item.ItemSequenceNumber = items.Count() + 1;
                items.Add(itemOrdered.Item);
                HttpContext.Session.SetJson("Items", items);
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

            //            TODO: handle errors
            if (ModelState.IsValid)
            {
                string shippingMetod = HttpContext.Session.GetString("ShippingMethod");
                shipData.ShippingMethod = shippingMetod;
                HttpContext.Session.SetJson("Shipment", shipData);
                return RedirectToAction("CustomerData");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public IActionResult CustomerData()
        {
            return View("CustomerData");
        }

        [HttpPost]
        public IActionResult CustomerData(OrderCustomerDataViewModel custData)
        {
            //            TODO: handle errors
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetJson("CustData", custData);
                return RedirectToAction("SubmitOrder");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> SubmitOrder()

        {


            //            TODO: handle errors
            OrderCustomer custData = HttpContext.Session.GetJson<OrderCustomer>("CustData");
            if (custData == null)
            {
                return Redirect("CustomerData");
            }
            List<Item> itemsList = HttpContext.Session.GetJson<List<Item>>("Items");
            var shipmentData = HttpContext.Session.GetJson<Shipment>("Shipment");
            if (shipmentData == null)
            {
                return Redirect("ShipmentData");
            }
            var shipmentsList = new List<Shipment>();
            shipmentsList.Add(shipmentData);
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
                    //TODO: handle product specific error -- go back to item and update or clear?
                }
                HttpContext.Session.Clear();
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