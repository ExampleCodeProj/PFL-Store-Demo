using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace PflStoreProject.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool HasTemplate { get; set; }
        public int QuantityDefault { get; set; }
        public int? QuantityIncrement { get; set; }
        public int? QuantityMaximum { get; set; }
        public int? QuantityMinimum { get; set; }
        public string ShippingMethodDefault { get; set; }
        public IEnumerable<DeliveredPrice> DeliveredPrices { get; set; }
        public IEnumerable<TemplateField> TemplateFields { get; set; }
    }

    public class TemplateField
    {
        public string Required { get; set; }
        public string Visible { get; set; }
        public string Type { get; set; }
        public string Linelimit { get; set; }
        public string FieldName { get; set; }
        public IEnumerable<Prompt> Prompts { get; set; }
        public string Default { get; set; }
        public string OrgValue { get; set; }
        public string HtmlFieldname { get; set; }
    }

    public class Prompt
    {
        public string Language { get; set; }
        public string Text { get; set; }
    }
}
