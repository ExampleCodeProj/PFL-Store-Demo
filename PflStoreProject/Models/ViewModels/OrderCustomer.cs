using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ViewModels
{
	public class OrderCustomer
	{
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
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
	}
	
}