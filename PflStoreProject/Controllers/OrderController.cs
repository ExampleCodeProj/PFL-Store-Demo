using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PflStoreProject.Infrastructure;
using PflStoreProject.Models;

namespace PflStoreProject.Controllers
{
    public class OrderController : Controller
    {
        private HttpClientService _client = new HttpClientService();
        public IActionResult CustomerDataForm(Data product)
        {
            //TODO: change state to 2 letter code
            var item = new OrderItemData()
            {   ItemSequenceNumber = 1,
                ProductId  = product.Id,
                Quantity = product.QuantityMinimum ?? 1,
            };
            HttpContext.Session.SetJson("Items", item);
            return View("CustomerData");
        }

        [HttpPost]
        public IActionResult CustomerData(OrderCustomerDataViewModel custData)
        {
     
            HttpContext.Session.SetJson("CustData", custData);
            HttpContext.Session.SetJson("Shipment", custData);
            return RedirectToAction("SubmitOrder");
        }

        public async Task<IActionResult> SubmitOrder()
        {
            var custData = HttpContext.Session.GetJson<OrderCustomer>("CustData");
            var item = HttpContext.Session.GetJson<Item>("Items");
            var shipment = HttpContext.Session.GetJson<Shipment>("Shipment");
            var itemList = new List<Item>();
            itemList.Add(item);
            var shipmentsList = new List<Shipment>();
            shipmentsList.Add(shipment);

            //TODO: change to proper order format
            var order = new Order()
            {
                partnerOrderReference = "123",
                orderCustomer = custData,
                items = itemList,
                shipments = shipmentsList,
            };
            // Test ORDER


            var response = await _client.SubmitOrder(order);
            return Json(response);
        }
    }
}