using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PflStoreProject.Models.ViewModels;

namespace PflStoreProject.Models
{
    public class OrderCustomer
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string companyName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string countryCode { get; set; } = "US";
        public string email { get; set; }
        public string phone { get; set; }
    }



    public class Shipment
    {
        public int ShipmentSequenceNumber { get; set; } = 1;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; } = "US";
        public string Phone { get; set; }
        public string shippingMethod { get; set; } = "FDXG";
        public string IMBSerialNumber { get; set; }
    }

    public class Payment
    {
        public string paymentMethod { get; set; }
        public string paymentID { get; set; }
        public double paymentAmount { get; set; }
    }

    public class ItemShipment
    {
        public int itemSequenceNumber { get; set; }
        public int shipmentSequenceNumber { get; set; }
    }

    public class CallbackHeaders
    {
        public string header_field_sample1 { get; set; }
        public string header_field_sample2 { get; set; }
    }

    public class Webhook
    {
        public string type { get; set; }
        public string callbackUri { get; set; }
        public CallbackHeaders callbackHeaders { get; set; }
    }

    public class BillingVariable
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Order
    {
        public string partnerOrderReference { get; set; }
        public OrderCustomer orderCustomer { get; set; }
        public List<Item> items { get; set; }
        public List<Shipment> shipments { get; set; }
        public List<Payment> payments { get; set; }
        public List<ItemShipment> itemShipments { get; set; }
        public List<Webhook> webhooks { get; set; }
        public List<BillingVariable> billingVariables { get; set; }
    }
}
