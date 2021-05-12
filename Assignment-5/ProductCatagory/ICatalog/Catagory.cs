using System;
using System.Collections.Generic;
using System.Text;

namespace ICatalog
{
    public class Catagory
    {
        private int id;
        private string name;
        private string shortCode;
        private string description;
        public int ID { get { return id; } }
        public string Name { get { return name; } }
        public string ShortCode { get { return shortCode; } }
        public string Description { get { return description; } }
        
        public Catagory(int id, string name, string shortCode, string desc)
        {
            this.id = id;
            this.name = name;
            this.shortCode = shortCode;
            this.description = desc;
        }
    }
}
