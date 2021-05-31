using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain.Models
{
    public class InventoryModel
    {
        public int OpeningStock { get; set; }
        public int StockPurchased { get; set; }
        public int StockSold { get; set; }
        public int ProductID { get; set; }
        public ProductModel Product { get; set; }
        public List<InventoryHistory> InventoryHistory { get; set; }
    }
}
