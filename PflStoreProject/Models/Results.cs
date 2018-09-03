using System.Collections.Generic;
using Newtonsoft.Json;

//ENTIRE PAYLOAD RECEIVED FROM API

namespace PflStoreProject.Models
{
    public class Results
    {
        [JsonProperty("errors")]
        public List<object> Errors { get; set; }
        [JsonProperty("messages")]
        public List<object> Messages { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

}
