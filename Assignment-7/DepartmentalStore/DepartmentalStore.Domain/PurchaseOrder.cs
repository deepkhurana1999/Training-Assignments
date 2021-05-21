using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class PurchaseOrder
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public ProductSupplier ProductSupplier { get; set; }
    }
}
