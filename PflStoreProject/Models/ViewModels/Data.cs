using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ViewModels
{
	public class Data
	{
		[JsonProperty("orderNumber")]
		public object OrderNumber { get; set; }
		[JsonProperty("partnerOrderReference")]
		public string PartnerOrderReference { get; set; }
		[JsonProperty("orderCustomer")]
		public OrderCustomer OrderCustomer { get; set; }
		[JsonProperty("items")]
		public List<Item> Items { get; set; }
		[JsonProperty("shipments")]
		public List<Shipment> Shipments { get; set; }
		[JsonProperty("mailings")]
		public object Mailings { get; set; }
		[JsonProperty("payments")]
		public List<Payment> Payments { get; set; }
		[JsonProperty("itemShipments")]
		public List<ItemShipment> ItemShipments { get; set; }
		[JsonProperty("webhooks")]
		public List<Webhook> Webhooks { get; set; }
		[JsonProperty("orderPrices")]
		public object OrderPrices { get; set; }
		[JsonProperty("billingVariables")]
		public List<BillingVariable> BillingVariables { get; set; }
	}
	
}