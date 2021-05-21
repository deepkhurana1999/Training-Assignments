using DepartmentalStore.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DepartmentalStore.Domain;

namespace DepartmentalStore.UI
{
    public static class QuerySolution
    {
        static DepartmentalStoreContext _context = new DepartmentalStoreContext();
        public static void QueryStaff(Func<Staff,bool> query)
        {
            var staffs = _context.Staff.AsNoTracking();
            var result = staffs.Where(query).Select(staff => new { staff.FirstName,staff.LastName,staff.PhoneNumber}).ToList();
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.FirstName}\t{entity.LastName}\t{entity.PhoneNumber}"));            
        }
        public static void QueryStaffWithJoin<T>(System.Linq.Expressions.Expression<Func<Staff, T>> joinquery,Func<Staff, bool> query)
        {
            var staffs = _context.Staff.AsNoTracking();
            var result = staffs.Include(joinquery).Where(query).Select(staff => new { staff.FirstName, staff.LastName, staff.PhoneNumber }).ToList();
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.FirstName}\t{entity.LastName}\t{entity.LastName}"));
        }
        public static void QueryProduct(Func<Product, bool> query)
        {
            var products = _context.Product.AsNoTracking();
            var result = products.Where(query).Select(product => new { product.Name, product.Code, product.Brand }).ToList();
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.Name}\t{entity.Code}\t{entity.Brand}"));
        }
        public static void QueryProductWithJoin<T>(System.Linq.Expressions.Expression<Func<Product, T>> joinquery,Func<Product, bool> query)
        {
            var products = _context.Product.AsNoTracking();
            var result = products.Include(joinquery).Where(query).Select(product => new { product.Name, product.Code, product.Brand }).ToList();
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.Name}\t{entity.Code}\t{entity.Brand}"));
        }
        public static void QueryProductWithCategory()
        {
            var products = _context.Product.AsNoTracking();
            var result = products.Include(product => product.ProductCategories).ThenInclude(productCategory => productCategory.Category)
                .Select(product => new { ProductName=product.Name,CategoryName=product.ProductCategories.Select(pc => pc.Category.Name)  }).ToList()
                .Where(entity => entity.CategoryName.Contains("Electronics")).ToList();
             Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.ProductName}\t{entity.CategoryName.FirstOrDefault()}"));
        }

        public static void QueryProductWithPrice()
        {
            var products = _context.Product.AsNoTracking();
            var result = products.Include(product => product.ProductPrices)
                .Where(entity => 
                entity.ProductPrices.Any(
                    x => x.PriceDate == entity.ProductPrices
                    .OrderBy(y => y.PriceDate).LastOrDefault().PriceDate)).Select(z => 
                    new { z.Name,z.ProductPrices.OrderByDescending(q => q.PriceDate).FirstOrDefault().PriceDate }).ToList();
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.Name},{entity.PriceDate}"));

        }
        public static void QueryProductWithStockCount()
        {
            var products = _context.Product.AsNoTracking();
            var result = products.Select(y=>y.AvailableQuantity==0).ToList();
            Console.Write("Result:\t");
            Console.WriteLine($"{result.Count()}");

        }
        public static void QueryCategoryWithProductCount()
        {
            var categories = _context.Category.AsNoTracking();
            var result = categories.Include(category => category.ProductCategories).ThenInclude(pc => pc.Product)
                .Select(entity => new { CategoryName = entity.Name, Count = entity.ProductCategories.Count }).ToList();
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.CategoryName},{entity.Count}"));
        }

        public static void QueryCategoryWithProductDesc()
        {
            var categories = _context.Category.AsNoTracking();
            var result = categories.Include(category => category.ProductCategories).ThenInclude(pc => pc.Product)
               .Select(entity => new { CategoryName = entity.Name, Count = entity.ProductCategories.Count })
               .OrderByDescending(x => x.Count).ToList();
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.CategoryName},{entity.Count}"));
        }
        public static void QuerySupplier(Func<Supplier,bool> query)
        {
            var suppliers = _context.Supplier.AsNoTracking();
            var result = suppliers.Where(query).Select(supplier => new { supplier.Name, supplier.Email, supplier.PhoneNumber }).ToList();
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.Name}\t{entity.Email}\t{entity.PhoneNumber}"));
        }
        public static void QuerySupplierwithAddress()
        {
            var suppliers = _context.Supplier.AsNoTracking();
            var result = suppliers.Include(supplier => supplier.Address).Where(x => x.Address.City.Equals("Kerala")).Select(supplier => new { supplier.Name, supplier.Email, supplier.PhoneNumber }).ToList();
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.Name}\t{entity.Email}\t{entity.PhoneNumber}"));
        }

        public static void QueryProductwithSupplierusingProductName()
        {
            var products = _context.Product.AsNoTracking();
            var result = products.Include(product => product.ProductSuppliers).ThenInclude(ps => ps.Supplier)
                .Where(product => product.Name.Equals("Lenovo P2")).ToList();
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.Name}\t{entity.Code}\t{entity.Brand}"));
        }
        public static void QueryProductwithSupplierusingProductCode()
        {
            var products = _context.Product.AsNoTracking();
            var result = products.Include(product => product.ProductSuppliers).ThenInclude(ps => ps.Supplier)
                .Where(product => product.Code.Equals("AI12SM")).ToList();
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.Name}\t{entity.Code}\t{entity.Brand}"));
        }
        public static void QueryProductwithSupplierusingSupplierName()
        {
            var products = _context.Product.AsNoTracking();
            var result = products.Include(product => product.ProductSuppliers).ThenInclude(ps => ps.Supplier)
                .Where(product => product.ProductSuppliers.Any(x => x.Supplier.Name.Equals("Njoy-Buying"))).ToList()
                .Select(product => new { ProductName=product.Name, SupplierName = product.ProductSuppliers.Find(x => x.Supplier.Name.Equals("Njoy-Buying")).Supplier.Name })
                .ToList();
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.ProductName}\t{entity.SupplierName}"));
        }
        public static void QueryProductwithSupplierusingSuppliedDate()
        {
            var purchaseOrder = _context.PurchaseOrder.AsNoTracking();
            var result = purchaseOrder.Include(po => po.ProductSupplier)
                .ThenInclude(ps => ps.Supplier)
                .Include(pSupplier => pSupplier.ProductSupplier.Product)
                .Where(po => po.PurchaseDate>new DateTime(2021,02,01))
                .ToList();
            
            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.Price}\t{entity.Quantity}"));
        }
        public static void QueryProductwithSupplierusingInventory()
        {
            var purchaseOrder = _context.PurchaseOrder.AsNoTracking();
            var result = purchaseOrder.Include(po => po.ProductSupplier)
                .ThenInclude(ps => ps.Supplier)
                .Include(pSupplier => pSupplier.ProductSupplier.Product)
                .ThenInclude(product => product.Inventory)
                .Where(entity => entity.ProductSupplier.Product.Inventory.OpeningStock
                        + entity.ProductSupplier.Product.Inventory.StockPurchased
                        - entity.ProductSupplier.Product.Inventory.StockSold>10)
                .ToList();

            Console.Write("Result:\t");
            result.ForEach(entity => Console.WriteLine($"{entity.Price}\t{entity.Quantity}"));
        }
    }
}
