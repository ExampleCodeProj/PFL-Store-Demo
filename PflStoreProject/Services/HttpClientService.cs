using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PflStoreProject.Models;

namespace PflStoreProject.Services
{
    public class HttpClientService
    {
        private IConfiguration _config;
        public HttpClient Client { get; }

        public HttpClientService(HttpClient client, IConfiguration config)
        {
            //get credientials from json file, encode and set up HttpClient
            _config = config;
            string credentials = _config.GetValue<string>("Credentials");
            string encodedCredentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
            client.BaseAddress= new Uri("https://testapi.pfl.com/");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", encodedCredentials);
            Client = client;
        }

        public async Task<string> GetProducts()
        {
                HttpResponseMessage response =
                    await Client.GetAsync("products?apikey=136085");
                string stringResult = await response.Content.ReadAsStringAsync();
                return stringResult;
        }

        public async Task<string> GetProductById(string id)
        {
                var response = await Client.GetAsync($"products?id={id}&apikey=136085");
                var stringResult = await response.Content.ReadAsStringAsync();
                return stringResult;
        }

        public async Task<JObject> SubmitOrder(Order order)
        {
                var jsonString = JsonConvert.SerializeObject(order);
                var orderString = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync($"orders?apikey=136085", orderString);
                var stringResult = await response.Content.ReadAsStringAsync();
                JObject productJson = JObject.Parse(stringResult);
                return productJson;
            }
        }
    
}

