using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ViewModels
{
	public class Item
	{
		[JsonProperty("itemSequenceNumber")]
		public int ItemSequenceNumber { get; set; }
		[JsonProperty("productID")]
		public int ProductID { get; set; }
		[JsonProperty("productName")]
		public object ProductName { get; set; }
		[JsonProperty("quantity")]
		public int Quantity { get; set; }
		[JsonProperty("itemFile")]
		public string ItemFile { get; set; }
		[JsonProperty("templateData")]
		public object TemplateData { get; set; }
		[JsonProperty("itemID")]
		public int ItemID { get; set; }
		[JsonProperty("partnerItemReference")]
		public string PartnerItemReference { get; set; }
		[JsonProperty("itemPrice")]
		public object ItemPrice { get; set; }
		[JsonProperty("productionDays")]
		public int ProductionDays { get; set; }
		[JsonProperty("templateDataURL")]
		public object TemplateDataURL { get; set; }
	}
	
}