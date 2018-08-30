// Item to bind to form

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ViewModels
{
	public class Item
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public string ItemFile { get; set; }
		// public object TemplateData { get; set; }
		public long ItemID { get; set; }
		public string PartnerItemReference { get; set; }
		// public ItemPrice ItemPrice { get; set; }
		public int ProductionDays { get; set; }
		// public string TemplateDataURL { get; set; }
	}
	
}