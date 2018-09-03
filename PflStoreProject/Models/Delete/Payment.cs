using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ViewModels
{
	public class Payment
	{
		[JsonProperty("paymentMethod")]
		public string PaymentMethod { get; set; }
		[JsonProperty("paymentID")]
		public string PaymentID { get; set; }
	}
	
}