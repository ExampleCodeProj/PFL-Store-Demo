using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PflStoreProject.Models
{
    public class HttpClientService
    {
        private const string Credentials = "miniproject:Pr!nt123";

        public string EncodedCredentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(Credentials));


        public async Task<List<ProductViewModel>> GetProducts()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", EncodedCredentials);
                var response = await client.GetAsync("https://testapi.pfl.com/products?apikey=136085");
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();

                JObject productJson = JObject.Parse(stringResult);
                IList<JToken> results = productJson["results"]["data"].Children().ToList();
                List<ProductViewModel> productList = new List<ProductViewModel>();
                foreach (JToken token in results)
                {
                    ProductViewModel product = token.ToObject<ProductViewModel>();
                    productList.Add(product);
                }

                return productList;
            }
        }

        public async Task<Data> GetProductById(string id)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", EncodedCredentials);
                var response = await client.GetAsync($"https://testapi.pfl.com/products?id={id}&apikey=136085");
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductsDetail>(stringResult);

                return product.Results.Data;

            }

        }
        
//        public async Task<String> SubmitOrder(Order order)
//        {
//
//            using (HttpClient client = new HttpClient())
//            {
//                client.DefaultRequestHeaders.Authorization =
//                    new AuthenticationHeaderValue("Basic", EncodedCredentials);
//                var jsonString = JsonConvert.SerializeObject(order);
//                var orderString = new StringContent(jsonString, Encoding.UTF8, "application/json");
//
//                var response = await client.PostAsync($"https://testapi.pfl.com/orders?apikey=136085", orderString);
//                response.EnsureSuccessStatusCode();
//                var stringResult = await response.Content.ReadAsStringAsync();
//
//                return stringResult;
//
//            }

            public async Task<JObject> SubmitOrder(Order order)
            {

                using (HttpClient client = new HttpClient())
                {
                    var json = @"{
    ""partnerOrderReference"": ""342423545"",
    ""orderCustomer"": {  
        ""firstName"": ""John"",  
        ""lastName"": ""Doe"",  
        ""companyName"": ""ACME"",  
        ""address1"": ""1 Acme Way"",  
        ""address2"": """",  
        ""city"": ""Livingston"",  
        ""state"": ""MT"",  
        ""postalCode"": ""59047"",  
        ""countryCode"": ""US"",  
        ""email"": ""jdoe@acme.com"",  
        ""phone"": ""1234567890""  
    },  
    ""items"": [  
        {  
            ""itemSequenceNumber"": 1,  
            ""productID"": 1234,  
            ""quantity"": 1000,  
            ""productionDays"": 4,                    
            ""partnerItemReference"": ""55555"",
            ""itemFile"": ""http://www.yourdomain.com/files/printReadyArtwork1.pdf""  
        }  
    ],  
    ""shipments"": [  
        {  
            ""shipmentSequenceNumber"": 1,  
            ""firstName"": ""John"",  
            ""lastName"": ""Doe"",  
            ""companyName"": ""ACME"",  
            ""address1"": ""1 Acme Way"",  
            ""address2"": """",  
            ""city"": ""Livingston"",  
            ""state"": ""MT"",  
            ""postalCode"": ""59047"",  
            ""countryCode"": ""US"",  
            ""phone"": ""1234567890"",  
            ""shippingMethod"": ""FDXG"",
            ""IMBSerialNumber"":""004543450""
        }  
    ],
     ""billingVariables"":[
        {
            ""key"":   ""BillingVariable1Name"",
            ""value"": ""BillingVariable1Value""
        },
        {
            ""key"":   ""BillingVariable2Name"",
            ""value"": ""BillingVariable2Value""
        }
    ]


}
            ";
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", EncodedCredentials);
                    var jsonString = JsonConvert.SerializeObject(order);
                    var orderString = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"https://testapi.pfl.com/orders?apikey=136085", orderString);
                   
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var dj = JsonConvert.DeserializeObject<JObject>(stringResult);
                    return dj;

                }

                
            }
    }
}