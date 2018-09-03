using Newtonsoft.Json;

//ENTIRE PAYLOAD RECEIVED FROM API

namespace PflStoreProject.Models
{
    public class ProductionSpeed
    {
        [JsonProperty("days")]
        public int Days { get; set; }
        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }
    }

}
