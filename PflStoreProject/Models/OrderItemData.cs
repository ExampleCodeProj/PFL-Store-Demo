using System.Collections.Generic;

namespace PflStoreProject.Models
{
    class OrderItemData
    {
        public short ItemSequenceNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ItemFile { get; set; }
        public List<OrderTemplateData> TemplateData { get; set; }
        public int ItemId { get; set; }
    }
}