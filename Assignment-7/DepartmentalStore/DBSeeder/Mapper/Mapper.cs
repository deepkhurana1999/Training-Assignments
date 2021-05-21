using DepartmentalStore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSeeder.Mapper
{
    public static class Mapper
    {
        public static Product ProductMapper(string data)
        {
            string[] productArr = data.Split(',');
            int quantity;
            int.TryParse(productArr[4], out quantity);
            return new Product { Name = productArr[0], Code = productArr[1], Brand = productArr[2], Manufacturer = productArr[3], AvailableQuantity = quantity };
        }
        public static Category CategoryMapper(string data)
        {
            string[] arr = data.Split(',');
            return new Category { Name = arr[0], Code = arr[1] };
        }
        public static ProductCategory ProductCategoryMapper(string data)
        {
            string[] arr = data.Split(',');
            int productID, categoryID;
            int.TryParse(arr[0], out productID);
            int.TryParse(arr[1], out categoryID);
            return new ProductCategory { ProductID = productID, CategoryID = categoryID };
        }
        public static ProductPrice ProductPriceMapper(string data)
        {
            string[] arr = data.Split(',');
            int cp, sp, discount, productID;
            DateTime priceDate;
            int.TryParse(arr[0], out cp);
            int.TryParse(arr[1], out sp);
            int.TryParse(arr[2], out discount);
            DateTime.TryParse(arr[3], out priceDate);
            int.TryParse(arr[4], out productID);
            return new ProductPrice { CostPrice = cp, SellingPrice = sp, Discount = discount, PriceDate = priceDate, ProductID = productID };
        }
        public static Inventory InventoryMapper(string data)
        {
            string[] arr = data.Split(',');
            int productID, openingStock, stockPurchased, stockSold;
            int.TryParse(arr[0], out productID);
            int.TryParse(arr[1], out openingStock);
            int.TryParse(arr[2], out stockPurchased);
            int.TryParse(arr[2], out stockSold);

            return new Inventory { ProductID = productID, OpeningStock=openingStock,StockPurchased=stockPurchased,StockSold=stockSold};
        }
        
    }
}
