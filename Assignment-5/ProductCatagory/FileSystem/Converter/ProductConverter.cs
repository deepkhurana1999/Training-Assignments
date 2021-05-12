using ICatalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Converter
{
    public static class ProductConverter
    {
        public static List<Product> ConvertToProducts(List<string> data)
        {
            List<Product> _products = new List<Product>();
            data.ForEach(line=> _products.Add(Mapper.Mapper.ProductMapper(line)));
            return _products;
        }

        public static List<string> ConvertToString(List<Product> data)
        {
            List<string> _products = new List<string>();
            data.ForEach(line => _products.Add(ConvertToString(line)));
            return _products;
        }

        public static string ConvertToString(Product product)
        {
            string categories = "";
            product.Categories.ForEach(x => categories = categories + $"{x.ID},{x.Name},{x.ShortCode},{x.Description};");
            return ($"{product.ID},{product.Name},{product.Manufacturer},{product.ShortCode},\"{categories.Substring(0, categories.Length - 1)}\",{product.Description},{product.SellingPrice}");
        }
    }
}
