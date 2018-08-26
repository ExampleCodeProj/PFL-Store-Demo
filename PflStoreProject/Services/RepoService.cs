using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PflStoreProject.Models;

namespace PflStoreProject.Services
{
    public class RepoService

    {
        private readonly HttpClient _httpClient;

        public RepoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var response = await _httpClient.GetAsync("products?apikey=136085");
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
}
