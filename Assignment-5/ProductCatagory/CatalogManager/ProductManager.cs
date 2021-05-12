using FileSystem.Converter;
using ICatalog;
using System;
using System.Collections.Generic;


namespace CatalogManager
{
    public class ProductManager
    {
        private static int idItr = 1;
        private static List<Product> _products;
        private static ProductManager productManagerObj;
        public static HashSet<string> shortCodeSet;
        static FileSystem.FileManager fileManager;
        private ProductManager()
        {
            shortCodeSet = new HashSet<string>();
            fileManager = new FileSystem.FileManager(@"C:\Users\Admin\source\repos\ProductCatagory\ProductCatagory\Data\Product.csv");
            _products = ProductConverter.ConvertToProducts(fileManager.GetAllData());
            _products.ForEach(x => shortCodeSet.Add(x.ShortCode));
        }

        public List<Product> Catagories
        {
            get { return _products; }
        }

        public void PrintAllProducts()
        {
            try
            {
                if (_products.Count <= 0)
                    throw new Exception("List is empty.");

                string categoriesList = "";
                Console.WriteLine("Name\t\tManufacturer\tShort Code\tDescription\tSelling Price\t\tCatagories");
                
                _products.ForEach(x => { x.Categories.ForEach(i => { categoriesList = categoriesList + i.Name + ", "; });
                    Console.WriteLine($"{x.Name}\t\t{x.Manufacturer}\t\t{x.ShortCode}\t\t{x.Description}\t\t{x.SellingPrice}\t\t{categoriesList}");
                    categoriesList = "";
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddProduct(string name, string manufacturer, string shortCode, List<Catagory> catagory, string desc, double sellPrice)
        {
            Product product = new Product(idItr++, name, manufacturer, shortCode, catagory, desc, sellPrice);
            _products.Add(product);
            fileManager.SaveData(ProductConverter.ConvertToString(product));
        }
        public void DeleteProduct(Predicate<Product> query)
        {
            int numberOfElementsRemoved = _products.RemoveAll(query);
            if(numberOfElementsRemoved>0)
                fileManager.DeleteData(ProductConverter.ConvertToString(_products));
        }

        public List<Product> SearchProduct(Predicate<Product> query)
        {
            var listFound = _products.FindAll(query);
            return listFound;
        }

        public static ProductManager getInstance()
        {
            if (productManagerObj == null)
            {
                productManagerObj = new ProductManager();
            }
            return productManagerObj;
        }
        public string ToString(ref List<Product> products)
        {
            string result = "Name\t\tManufacturer\tShort Code\tDescription\tSelling Price\t\tCatagories";
            products.ForEach(x => result = result + (($"{x.Name}\t\t{x.Manufacturer}\t\t{x.ShortCode}\t\t{x.Description}\t\t{x.SellingPrice}")));

            string categoriesList = "";
            _products.ForEach(x => x.Categories.ForEach(i => {
                categoriesList = categoriesList + i.Name;
               result = result + ($"{x.Name}\t\t{x.Manufacturer}\t\t{x.ShortCode}\t\t{x.Description}\t\t{x.SellingPrice}\t\t{categoriesList}");
            }));
            return result;
        }
    }
}
