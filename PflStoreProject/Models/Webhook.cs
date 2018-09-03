//submit to API



namespace PflStoreProject.Models
{
    public class Webhook
    {
        public string type { get; set; }
        public string callbackUri { get; set; }
        public CallbackHeaders callbackHeaders { get; set; }
    }
}
