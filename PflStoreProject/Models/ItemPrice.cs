//ORDER CONFIRMATION

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PflStoreProject.Models.ViewModels
{
    public class ItemPrice
    {
        [JsonProperty("envelopePrice")]
        public int EnvelopePrice { get; set; }
        [JsonProperty("mailingPrice")]
        public int MailingPrice { get; set; }
        [JsonProperty("printingCostEach")]
        public double PrintingCostEach { get; set; }
        [JsonProperty("printPrice")]
        public double PrintPrice { get; set; }
        [JsonProperty("promotionalDiscount")]
        public int PromotionalDiscount { get; set; }
        [JsonProperty("retailFulfillmentPrice")]
        public int RetailFulfillmentPrice { get; set; }
        [JsonProperty("retailPrintPrice")]
        public int RetailPrintPrice { get; set; }
        [JsonProperty("retailReimbursementPrice")]
        public int RetailReimbursementPrice { get; set; }
        [JsonProperty("retailRushPrice")]
        public int RetailRushPrice { get; set; }
        [JsonProperty("retailShippingPrice")]
        public int RetailShippingPrice { get; set; }
        [JsonProperty("rushPrice")]
        public int RushPrice { get; set; }
        [JsonProperty("secondSheetPrice")]
        public int SecondSheetPrice { get; set; }
        [JsonProperty("shipPrice")]
        public double ShipPrice { get; set; }
        [JsonProperty("totalPrice")]
        public double TotalPrice { get; set; }
        [JsonProperty("totalPrintingPrice")]
        public double TotalPrintingPrice { get; set; }
    }
}
