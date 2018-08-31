using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace PflStoreProject.Models.ApiProductDetails
{
	public class Field
	{
		[JsonProperty("required")]
		public string Required { get; set; }
		[JsonProperty("visible")]
		public string Visible { get; set; }
		[JsonProperty("type")]
		public string Type { get; set; }
		[JsonProperty("subtype")]
		public string Subtype { get; set; }
		[JsonProperty("autosort")]
		public string Autosort { get; set; }
		[JsonProperty("fieldname")]
		public string Fieldname { get; set; }
		[JsonProperty("prompt")]
		public List<Prompt> Prompt { get; set; }
		[JsonProperty("default")]
		public string Default { get; set; }
		[JsonProperty("orgvalue")]
		public string Orgvalue { get; set; }
		[JsonProperty("htmlfieldname")]
		public string Htmlfieldname { get; set; }
		[JsonProperty("picklist")]
		public Picklist Picklist { get; set; }
	}
	
}