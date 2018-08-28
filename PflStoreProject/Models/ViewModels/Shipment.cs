using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ViewModels
{
	public class Shipment
	{
		[JsonProperty("shipmentSequenceNumber")]
		public int ShipmentSequenceNumber { get; set; }
		[JsonProperty("firstName")]
		public string FirstName { get; set; }
		[JsonProperty("lastName")]
		public string LastName { get; set; }
		[JsonProperty("companyName")]
		public string CompanyName { get; set; }
		[JsonProperty("address1")]
		public string Address1 { get; set; }
		[JsonProperty("address2")]
		public string Address2 { get; set; }
		[JsonProperty("city")]
		public string City { get; set; }
		[JsonProperty("state")]
		public string State { get; set; }
		[JsonProperty("postalCode")]
		public string PostalCode { get; set; }
		[JsonProperty("countryCode")]
		public string CountryCode { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("shippingMethod")]
		public string ShippingMethod { get; set; }
		[JsonProperty("returnAddress")]
		public object ReturnAddress { get; set; }
		[JsonProperty("description")]
		public object Description { get; set; }
		[JsonProperty("imbSerialNumber")]
		public string ImbSerialNumber { get; set; }
	}
	
}