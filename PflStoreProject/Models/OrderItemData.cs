using System.Collections.Generic;

namespace PflStoreProject.Models
{
    public class OrderItemData
    {
        public short ItemSequenceNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public List<OrderTemplateData> TemplateData { get; set; }
        
    }
}