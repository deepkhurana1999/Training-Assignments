using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class ProductPrice
    {
        public int ID { get; set; }
        public float CostPrice { get; set; }
        public float SellingPrice { get; set; }
        public int Discount { get; set; }
        public DateTime PriceDate { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }

    }
}
