//submit to API



namespace PflStoreProject.Models
{
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
}
