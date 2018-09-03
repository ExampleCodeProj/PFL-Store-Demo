using Newtonsoft.Json;

namespace PflStoreProject.Models
{
    public class Meta
    {
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("duration")]
        public int Duration { get; set; }
    }
}