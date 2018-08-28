using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PflStoreProject.Models
{
    public class OrderItemData
    {
        public short ItemSequenceNumber { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string ItemFile { get; set; }
        public List<OrderTemplateData> TemplateData { get; set; }
        public long ItemID { get; set; }
    }
}
