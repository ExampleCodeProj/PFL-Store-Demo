using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ApiProductDetails
{
	public class TemplateFields
	{
		[JsonProperty("fieldlist")]
		public Fieldlist Fieldlist { get; set; }
	}
	
}