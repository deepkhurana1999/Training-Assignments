using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
        public List<ProductSupplier> ProductSuppliers { get; set; }

        public Supplier()
        {
            ProductSuppliers = new List<ProductSupplier>();
        }
    }
}
