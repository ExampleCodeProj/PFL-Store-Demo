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
using PflStoreProject.Models;
using PflStoreProject.Models.ViewModels;

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
                    HttpResponseMessage response =
                        await client.GetAsync("https://testapi.pfl.com/products?apikey=136085");
                    response.EnsureSuccessStatusCode();
                    // read response body into buffer as a string
                    string stringResult = await response.Content.ReadAsStringAsync();
                    // parse/interpret string into JObject to make queryable by linq and extract desired parts
                    JObject queryable = JObject.Parse(stringResult);
                    // extract only the data section to convert to model
                    IList<JToken> results = queryable["results"]["data"].Children().ToList();
                    List<ProductViewModel> productList = new List<ProductViewModel>();
                    // loop throgh the JObject, map to model and add to the model collection
                    foreach (JToken token in results)
                    {
                        ProductViewModel product = token.ToObject<ProductViewModel>();
                        productList.Add(product);
                    }

                    return productList;





            }
        }

        public async Task<string> GetProductById(string id)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", EncodedCredentials);
                var response = await client.GetAsync($"https://testapi.pfl.com/products?id={id}&apikey=136085");
                var stringResult = await response.Content.ReadAsStringAsync();
                return stringResult;

//                var product = JsonConvert.DeserializeObject<ProductsDetail>(stringResult);
//
//                return product;



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