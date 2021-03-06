﻿using System.Collections.Generic;
using PflStoreProject.Models.ViewModels;

namespace PflStoreProject.Models
{
    public class NewOrderPayload
    {
        public string OrderNumber
        {
            get;
            set;
        }

        public string PartnerOrderReference
        {
            get;
            set;
        }

        public OrderCustomer OrderCustomer
        {
            get;
            set;
        }

        public List<Item> Items
        {
            get;
            set;
        }

        public List<OrderShipmentData> Shipments
        {
            get;
            set;
        }
    }
    public class OrderTemplateData
    {
        public string TemplateDataName { get; set; }
        public string TemplateDataValue { get; set; }
    }
    public class OrderShipmentData
    {
        public short ShipmentSequenceNumber
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;
        }

        public string Address1
        {
            get;
            set;
        }

        public string Address2
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public string PostalCode
        {
            get;
            set;
        }

        public string CountryCode
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public string ShippingMethod
        {
            get;
            set;
        }
    }
}