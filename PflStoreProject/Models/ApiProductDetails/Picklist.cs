using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ApiProductDetails
{
	public class Picklist
	{
		[JsonProperty("item")]
		public List<Item> Item { get; set; }
	}
	
}