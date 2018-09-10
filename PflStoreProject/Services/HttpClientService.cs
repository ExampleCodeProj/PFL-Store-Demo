using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PflStoreProject.Models;

namespace PflStoreProject.Services
{
    public class HttpClientService
    {
        private IConfiguration _config;
        public HttpClient Client { get; }

        public HttpClientService(HttpClient client, IConfiguration config)
        {
//            get credientials from json file, encode and set up HttpClient
            _config = config;
            string credentials = _config.GetValue<string>("Credentials");
            string encodedCredentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
            client.BaseAddress = new Uri("https://testapi.pfl.com/");
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
            HttpResponseMessage response = await Client.GetAsync($"products?id={id}&apikey=136085");
            string stringResult = await response.Content.ReadAsStringAsync();
            return stringResult;
        }

        public async Task<string> SubmitOrder(Order order)
        {
            string jsonString = JsonConvert.SerializeObject(order);
            StringContent orderString = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync($"orders?apikey=136085", orderString);
            string stringResult = await response.Content.ReadAsStringAsync();
            return stringResult;
        }
    }

}

