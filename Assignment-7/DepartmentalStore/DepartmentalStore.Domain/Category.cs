using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
        
        public Category()
        {
            ProductCategories = new List<ProductCategory>();
        }
    }
}
