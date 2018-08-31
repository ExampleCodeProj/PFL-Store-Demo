using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ApiProductDetails
{
	public class Fieldlist
	{
		[JsonProperty("field")]
		public List<Field> Field { get; set; }
	}
	
}