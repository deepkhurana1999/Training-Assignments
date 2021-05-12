using System;
using System.Collections.Generic;
using System.Text;

namespace ICatalog
{
    public class Product
    {
        private int id;
        private string name;
        private string manufacturer;
        private string shortCode;
        private List<Catagory> categories;
        private double sellingPrice;
        private string description;

        public int ID { get { return id; } }
        public string Name { get { return name; } }
        public string Manufacturer { get { return manufacturer; } }
        public string ShortCode { get { return shortCode; } }
        public List<Catagory> Categories { get { return categories; } }
        public string Description { get { return description; } }
        public double SellingPrice { get { return sellingPrice; } }

        public Product(int id, string name, string manufacturer, string shortCode, List<Catagory> catagory, string desc, double sellPrice)
        {
            this.id = id;
            this.name = name;
            this.manufacturer = manufacturer;
            this.shortCode = shortCode;
            this.categories = catagory;
            this.description = desc;
            this.sellingPrice = sellPrice;
        }
    }
}
