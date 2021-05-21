using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class InventoryHistory
    {
        public int ID { get; set; }
        public int InventoryID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }

        public Inventory Inventory { get; set; }
    }
}
