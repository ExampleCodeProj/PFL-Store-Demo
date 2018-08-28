using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ViewModels
{
	public class ItemShipment
	{
		[JsonProperty("itemSequenceNumber")]
		public int ItemSequenceNumber { get; set; }
		[JsonProperty("shipmentSequenceNumber")]
		public int ShipmentSequenceNumber { get; set; }
		[JsonProperty("quantity")]
		public object Quantity { get; set; }
		[JsonProperty("itemFile")]
		public object ItemFile { get; set; }
		[JsonProperty("reference")]
		public object Reference { get; set; }
	}
	
}