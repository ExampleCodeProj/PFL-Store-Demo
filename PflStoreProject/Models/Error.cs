using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ViewModels
{
	public class Error
	{
		[JsonProperty("dataElement")]
		public string DataElement { get; set; }
		[JsonProperty("dataElementErrors")]
		public List<string> DataElementErrors { get; set; }
	}
	
}