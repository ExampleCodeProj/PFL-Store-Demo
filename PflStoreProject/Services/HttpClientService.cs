using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PflStoreProject.Models
{
    public class HttpClientService
    {
        private const string Credentials = "miniproject:Pr!nt123";

        public string EncodedCredentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(Credentials));


        public async Task<string> GetProducts()
        {
            var path = @"C:\Users\bethh\source\repos\PflStoreProject\PflStoreProject\SampleData\products.json";
            var res = File.ReadAllText(path);
            return res;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", EncodedCredentials);
                HttpResponseMessage response =
                    await client.GetAsync("https://testapi.pfl.com/products?apikey=136085");
                string stringResult = await response.Content.ReadAsStringAsync();
                return stringResult;
            }
        }

        public async Task<string> GetProductById(string id)
        {
            var path = @"C:\Users\bethh\source\repos\PflStoreProject\PflStoreProject\SampleData\ProductDetails22784.json";
            var res = File.ReadAllText(path);
            return res;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", EncodedCredentials);
                var response = await client.GetAsync($"https://testapi.pfl.com/products?id={id}&apikey=136085");
                var stringResult = await response.Content.ReadAsStringAsync();
                return stringResult;
            }
        }

        public async Task<JObject> SubmitOrder(Order order)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", EncodedCredentials);
                var jsonString = JsonConvert.SerializeObject(order);
                var orderString = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"https://testapi.pfl.com/orders?apikey=136085", orderString);

                var stringResult = await response.Content.ReadAsStringAsync();
                JObject productJson = JObject.Parse(stringResult);
                return productJson;
            }
        }
    }
}


//
//
//            public async Task<JObject> SubmitOrder(Order order)
//            {
//
//                using (HttpClient client = new HttpClient())
//                {

//                    client.DefaultRequestHeaders.Authorization =
//                        new AuthenticationHeaderValue("Basic", EncodedCredentials);
//                    var jsonString = JsonConvert.SerializeObject(order);
//                    var orderString = new StringContent(json, Encoding.UTF8, "application/json");
//
//                    var response = await client.PostAsync($"https://testapi.pfl.com/orders?apikey=136085", orderString);
//                   
//                    var stringResult = await response.Content.ReadAsStringAsync();
//                    var dj = JsonConvert.DeserializeObject<JObject>(stringResult);
//                    return dj;
//
//                }
//
//                
//            }
//    }
//}