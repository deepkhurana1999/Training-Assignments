using ICatalog;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Mapper
{
    static class Mapper
    {
        public static Product ProductMapper(string data)
        {
            
            string[] dataPartition = data.Split('"');
            string productValue = dataPartition[0].Substring(0,dataPartition[0].Length-1) + dataPartition[2];
            string catagoryValue = dataPartition[1];

            List<Catagory> _productCatagories = ProductCatagoryMapper(catagoryValue);


            string[] productArr = productValue.Split(',');
            int id, price;
            int.TryParse(productArr[0], out id);
            int.TryParse(productArr[4], out price);
            return new Product(id, productArr[1], productArr[2], productArr[3], _productCatagories, productArr[4], price);
        }

        private static List<Catagory> ProductCatagoryMapper(string data)
        {
            string[] dataArr = data.Split(';');
            List<Catagory> _productCatagory = new List<Catagory>();
            foreach(var categoryData in dataArr)
            {
                _productCatagory.Add(CatagoryMapper(categoryData));
            }
            return _productCatagory;
        }

        public static Catagory CatagoryMapper(string data)
        {
            string[] categoryArr = data.Split(',');
            int id;
            int.TryParse(categoryArr[0], out id);
            return new Catagory(id, categoryArr[1], categoryArr[2], categoryArr[3]);
        }
    }
}
