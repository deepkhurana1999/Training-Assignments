using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class Inventory
    {
        public int ID { get; set; }
        public int OpeningStock { get; set; }
        public int StockPurchased { get; set; }
        public int StockSold { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public List<InventoryHistory> InventoryHistory { get; set; }

        public Inventory()
        {
            InventoryHistory = new List<InventoryHistory>();
        }
    }
}
