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

        public async Task<Data> GetProductById(string id) { 
        
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
    }
}