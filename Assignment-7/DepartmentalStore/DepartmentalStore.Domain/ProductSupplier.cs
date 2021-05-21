using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class ProductSupplier
    {
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}
