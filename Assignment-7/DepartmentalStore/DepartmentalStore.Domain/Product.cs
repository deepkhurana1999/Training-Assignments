using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Manufacturer { get; set; }
        public string Code { get; set; }
        public int AvailableQuantity { get; set; }
        public Inventory Inventory { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductSupplier> ProductSuppliers { get; set; }
        public List<ProductPrice> ProductPrices { get; set; }
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
            ProductSuppliers = new List<ProductSupplier>();
            ProductPrices = new List<ProductPrice>();
        }
    }
}
