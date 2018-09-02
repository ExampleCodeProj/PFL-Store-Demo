// Item to bind to form

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace PflStoreProject.Models.ViewModels
{
	public class Item
	{
	    public int ItemSequenceNumber { get; set; }
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public string ItemFile { get; set; }
		public List<TemplateData> TemplateData { get; set; }
//		public long ItemID { get; set; }
		public string PartnerItemReference { get; set; }
		// public ItemPrice ItemPrice { get; set; }
		public int ProductionDays { get; set; }
		// public string TemplateDataURL { get; set; }
	}
    public class TemplateData
    {
        [JsonProperty("templateDataName")]
        public string TemplateDataName { get; set; }
        [JsonProperty("templateDataValue")]
        public string TemplateDataValue { get; set; }
    }
}