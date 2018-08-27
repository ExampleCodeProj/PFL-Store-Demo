using System;
using System.Linq;
using System.Threading.Tasks;

namespace PflStoreProject.Models
{
    public class OrderCustomerData
    {
        
        
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

        public string CountryCode { get; set; } = "US";

            public string Email
            {
                get;
                set;
            }

            public string Phone
            {
                get;
                set;
            }
        
    }
}
