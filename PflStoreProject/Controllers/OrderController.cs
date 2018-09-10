using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PflStoreProject.Infrastructure;
using PflStoreProject.Models;
using PflStoreProject.Models.ViewModels;
using PflStoreProject.Services;
using OrderCustomer = PflStoreProject.Models.OrderCustomer;
using Shipment = PflStoreProject.Models.Shipment;

namespace PflStoreProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly HttpClientService _client;
        
        public OrderController(HttpClientService client)
        {
            _client = client;
        }

//        blob client service "DesignStore" is injected to this action only so not recreated every call to controller
        [HttpPost]
        public async Task<IActionResult> CreateOrderItem([FromServices]DesignStore designStore,  ProductDetailViewModel itemOrdered, IFormFile fileUpload, Int16 quantity)
        {
//            TODO: serverside validate quantity
            itemOrdered.Item.Quantity = quantity;
//            Processing determined by user radio button selection of Design Options
            if (itemOrdered.DesignOption == "designFile")
            {
//               TODO: add validation for file upload
                if (fileUpload != null)
                {
                    using (var stream = fileUpload.OpenReadStream())
                    {
                        var fileUrl = await designStore.SaveFile(stream);
                        itemOrdered.Item.ItemFile = fileUrl;
                    }
                }
            }

//            if customer chose template option, capture the data, validate and save to order item
            if (itemOrdered.DesignOption == "designTemplate")
            {
                List<TemplateData> templateDataList = new List<TemplateData>();
                foreach (Field field in itemOrdered.Detail.TemplateFields.Fieldlist.Field)
                {
//                    TODO: add simplied template object into ProductDetailsViewModel
//                    TODO: perform validation on fields
                    TemplateData data = new TemplateData
                    {
                        TemplateDataName = field.Htmlfieldname,
                        TemplateDataValue = field.Fieldname
                    };
                    templateDataList.Add(data);
                }
                itemOrdered.Item.TemplateData = templateDataList;
            }
//            TODO: add validation -- min/max and increment for quantity
//            Get all items out of session, convert back to ItemList, add new item, save back into session
//            allows for future extensibility to add multiple items -- currently, flow only allows one item per shipment/order
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
            if (ModelState.IsValid)
            {
                string shippingMetod = HttpContext.Session.GetString("ShippingMethod");
                shipData.ShippingMethod = shippingMetod;
                HttpContext.Session.SetJson("Shipment", shipData);
                return RedirectToAction("CustomerData");
            }
            return View();
        }


        [HttpGet]
        public IActionResult CustomerData()
        {
            return View("CustomerData");
        }


        [HttpPost]
        public IActionResult CustomerData(OrderCustomerDataViewModel custData)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetJson("CustData", custData);
                return RedirectToAction("SubmitOrder");
            }
            return View();
        }


        public async Task<IActionResult> SubmitOrder()
        {
            List<Item> itemsList = HttpContext.Session.GetJson<List<Item>>("Items");
            OrderCustomer custData = HttpContext.Session.GetJson<OrderCustomer>("CustData");
            if (custData == null)
            {
                return Redirect("CustomerData");
            }
            Shipment shipmentData = HttpContext.Session.GetJson<Shipment>("Shipment");
            if (shipmentData == null)
            {
                return Redirect("ShipmentData");
            }
            List<Shipment> shipmentsList = new List<Shipment>();
            shipmentsList.Add(shipmentData);
            Order order = new Order
            {
                orderCustomer = custData,
                items = itemsList,
                shipments = shipmentsList
            };
            try
            {
                string response = await _client.SubmitOrder(order);
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
                    HttpContext.Session.Remove("Items");
//                    TODO: handle product specific error -- should user be able to edit, or clear and start over?
                    return View("Errors", errorsList);
                }

                HttpContext.Session.Clear();
                NewOrderPayload orderData = queryableResponse["results"]["data"].ToObject<NewOrderPayload>();
                
                return View("OrderConfirmation", orderData);
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

//TODO: Add "ReviewOrder" and "Edit" action methods allowing user to inspect inputs and update before submitting order