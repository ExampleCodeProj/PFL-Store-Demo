//Item object returned after SUBMIT 9with Payload)

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using PflStoreProject.Models.ViewModels;

namespace PflStoreProject.Models
{
	public class OrderItem
	{
	    [JsonProperty("itemSequenceNumber")] public int ItemSequenceNumber { get; set; } = 1;
		[JsonProperty("productID")]
		public int ProductID { get; set; }
		[JsonProperty("productName")]
		public string ProductName { get; set; }
		[JsonProperty("quantity")]
		public int Quantity { get; set; }
		[JsonProperty("itemFile")]
		public string ItemFile { get; set; }
		[JsonProperty("templateData")]
		public object TemplateData { get; set; }
		[JsonProperty("itemID")]
		public long ItemID { get; set; }
		[JsonProperty("partnerItemReference")]
		public string PartnerItemReference { get; set; }
		[JsonProperty("itemPrice")]
		public ItemPrice ItemPrice { get; set; }
		[JsonProperty("productionDays")]
		public int ProductionDays { get; set; }
		[JsonProperty("templateDataURL")]
		public string TemplateDataURL { get; set; }
	}
	
}