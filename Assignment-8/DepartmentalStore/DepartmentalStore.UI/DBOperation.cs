using DepartmentalStore.Data;
using System.Linq;
using System;
using DepartmentalStore.Domain;
using System.Collections.Generic;

namespace DepartmentalStore.UI
{
    static class DBOperation
    {
        static DepartmentalStoreContext _context = new DepartmentalStoreContext();
        public static void SeedData()
        {
            _context.Database.EnsureCreated();
            AddProductData();
            AddCategoryData();
            AddProductCategoryData();
            AddProductPrice();
            AddInventoryData();
            AddAddressData();
            AddSupplierData();
            AddProductSupplierData();
            AddDesignationData();
            AddStaffData();
            AddPurchaseOrderData();
        }
        public static void AddProductData()
        {
            Product[] _products = {
                new Product{ Name ="Lenovo Ideapad",Code="LI2020LAP",Brand="Ideapad",Manufacturer="Lenovo",AvailableQuantity=90 },
                new Product{ Name = "Lenovo P2", Code = "LPSM", Brand ="P", Manufacturer="Lenovo",AvailableQuantity=37},
                new Product{ Name = "Norton Antivirus 2020", Code = "NA2020SW", Brand ="Norton Antivirus", Manufacturer="Norton",AvailableQuantity=40},
                new Product{ Name = "Apple Iphone 12", Code = "AI12SM", Brand ="Iphone", Manufacturer="Apple",AvailableQuantity=500000},
                new Product{ Name = "Lindt Dark Chocolate", Code = "LDCHOCDRYP", Brand ="Dark Chocolate", Manufacturer="Lindt",AvailableQuantity=0},
                new Product{ Name = "Microsoft Windows 10", Code = "W10SW", Brand ="Windows", Manufacturer="Microsoft",AvailableQuantity=100000},
                new Product{ Name = "Alemannenkäse Cheese", Code = "ACDRYP", Brand ="Alemannenkäse Bio", Manufacturer="Alemannenkäse",AvailableQuantity=0} 
            };
            
            _context.Product.AddRange(_products);
            _context.SaveChanges();
        }
        public static void AddProductPrice()
        {
            ProductPrice[] _productPrice = {
                new ProductPrice { CostPrice = 80000, SellingPrice = 100000, Discount = 0, PriceDate= new DateTime(2021,01,01), ProductID=1 },
                new ProductPrice { CostPrice = 80000, SellingPrice =120000, Discount = 0, PriceDate=new DateTime(2021,05,01), ProductID=1 },
                new ProductPrice { CostPrice = 10000, SellingPrice = 15000, Discount = 0, PriceDate= new DateTime(2015, 07, 01), ProductID=2 },
                new ProductPrice { CostPrice = 5000, SellingPrice = 10000, Discount = 0, PriceDate = new DateTime(2021, 04, 01), ProductID = 2 },
                new ProductPrice { CostPrice = 500, SellingPrice =800, Discount= 0, PriceDate=new DateTime(2021,04,01), ProductID=3 },
                new ProductPrice { CostPrice = 100000, SellingPrice =120000, Discount=0, PriceDate=new DateTime(2020,05,01), ProductID=4 },
                new ProductPrice { CostPrice = 60000, SellingPrice =84000, Discount=0, PriceDate=new DateTime(2021,04,01), ProductID=4 },
                new ProductPrice { CostPrice = 100, SellingPrice =150, Discount =20, PriceDate=new DateTime(2021,04,01), ProductID=5 },
                new ProductPrice { CostPrice = 7000, SellingPrice =9290, Discount=20, PriceDate=new DateTime(2021,02,01), ProductID=6 },
                new ProductPrice { CostPrice = 1000, SellingPrice =1500, Discount=0, PriceDate= new DateTime(2021,03,01), ProductID=7 } 
            };
            _context.AddRange(_productPrice);
            _context.SaveChanges();
        }
        public static void AddCategoryData()
        {
            Category[] _categories = {
                new Category{ Name ="Software",Code="SW"},
                new Category{ Name = "Hardware", Code = "HW"},
                new Category{ Name = "Smartphone", Code = "SM"},
                new Category{ Name = "Dairy Products", Code = "DRYP"},
                new Category{ Name = "Laptop", Code = "LAP"},
                new Category{ Name = "Electronics", Code = "ELEC"}
            };
            _context.Category.AddRange(_categories);
            _context.SaveChanges();
        }
        public static void AddProductCategoryData()
        {
            ProductCategory[] _productCategories = {
                new ProductCategory{ ProductID=1, CategoryID=5 },
                new ProductCategory{ProductID=1, CategoryID=6 },
                new ProductCategory{ProductID=2, CategoryID=3 },
                new ProductCategory{ ProductID = 2, CategoryID = 6 },
                new ProductCategory{ProductID=3, CategoryID=1 },
                new ProductCategory{ProductID=4, CategoryID=3 },
                new ProductCategory{ProductID=4, CategoryID=6},
                new ProductCategory{ProductID=5, CategoryID=4 },
                new ProductCategory{ProductID=6, CategoryID=1 },
                new ProductCategory{ProductID=7, CategoryID=4 }
            };
            _context.AddRange(_productCategories);
            _context.SaveChanges();
        }
        public static void ShowData()
        {
            var products = _context.Product.ToList();
            products.ForEach(x => Console.WriteLine(x.ID));
        }

        public static void AddInventoryData()
        {
            Inventory[] _inventories=
            {
                new Inventory{ ProductID=1,OpeningStock=100,StockPurchased=0,StockSold=10 },
                new Inventory{ ProductID=2,OpeningStock=50,StockPurchased=10,StockSold=23 },
                new Inventory{ ProductID=3,OpeningStock=60,StockPurchased=10,StockSold=30},
                new Inventory{ ProductID=4,OpeningStock=1000000,StockPurchased=500000,StockSold=1000000 },
                new Inventory{ ProductID=5,OpeningStock=10,StockPurchased=0,StockSold=10 },
                new Inventory{ ProductID=6,OpeningStock=50000,StockPurchased=100000,StockSold=50000 },
                new Inventory{ ProductID=7,OpeningStock=0,StockPurchased=0,StockSold=0}
            };
            _context.Inventory.AddRange(_inventories);
            _context.SaveChanges();
        }

        public static void AddAddressData()
        {
            List<Address> _list = new List<Address> 
            {
                new Address{AddressLine1="26/1, 10th Floor",AddressLine2="Brigade World Trade Center,Dr. Rajkumar Road",State="Banglore",Country="India",PinCode="560055" },
                new Address { AddressLine1 = "Synthite Industries Private Limited", AddressLine2 = "Synthite Valley Kolenchery", City = "Ernakulam", State = "Kerala", Country = "India", PinCode = "682311" },
                new Address{AddressLine1="Address1",AddressLine2="Address1.2",City="New Delhi",State="Delhi",Country="India",PinCode="110008"},
                new Address{AddressLine1="Address2",AddressLine2="Address2.2",City="Banglore",State="Karnataka",Country="India",PinCode="550068" },
                new Address{AddressLine1="Address3",AddressLine2="Address3.2",City="Banglore",State="Karnataka",Country="India",PinCode="550068" }
        };
            _context.Set<Address>().AddRange(_list);
            _context.SaveChanges();
        }
        
        public static void AddSupplierData()
        {
            Supplier[] _list = 
            {
                new Supplier{Name="Njoy-Buying",PhoneNumber="2345678961",Email="n@gmail.com",AddressID=1 },
                new Supplier{Name="Synthite Industries Private Limited",PhoneNumber="4562319876",Email="s@gmail.com",AddressID=2 },
                new Supplier{Name="Appario Retail Private Ltd",PhoneNumber="2346189432",Email="a@gmail.com",AddressID=1},
                new Supplier{Name="Arham World",PhoneNumber="7629520971",Email="ar@gmail.com",AddressID=1 }
            };
            _context.Supplier.AddRange(_list);
            _context.SaveChanges();
        }
        public static void AddProductSupplierData()
        {
            ProductSupplier[] _list = 
            {
                new ProductSupplier{ ProductID =1 , SupplierID=1},
                new ProductSupplier{ ProductID =1 , SupplierID=3},
                new ProductSupplier{ ProductID =2 , SupplierID=3},
                new ProductSupplier{ ProductID = 3, SupplierID=4},
                new ProductSupplier{ ProductID = 4, SupplierID=1},
                new ProductSupplier{ ProductID = 4, SupplierID=3},
                new ProductSupplier{ ProductID = 5, SupplierID=2},
                new ProductSupplier{ ProductID = 6, SupplierID=4},
                new ProductSupplier{ ProductID = 7, SupplierID=2}
            };
            _context.AddRange(_list);
            _context.SaveChanges();
        }
        public static void AddDesignationData()
        {
            Designation[] _list = 
            {
                new Designation{Name="Stock Maintainer"},
                new Designation{Name="Cashier"},
                new Designation{Name="Helper"}
            };
            _context.AddRange(_list);
            _context.SaveChanges();
        }

        public static void AddStaffData()
        {
            Product[] _list = 
            {
                new Product{ FirstName="Person1", LastName="last1", AddressID=3, DesignationID=1, PhoneNumber="1568234098", Gender='M' },
                new Product{ FirstName="Person2",LastName="last2",AddressID=4,DesignationID=2,PhoneNumber="5162234098",Gender='F' },
                new Product{ FirstName="Person3", LastName="last3",AddressID=4,DesignationID=3,PhoneNumber="1569234098",Gender='F'},
                new Product{ FirstName="Person4", LastName="last4",AddressID=5,DesignationID=3,PhoneNumber="1234567890",Gender='M'},
            };
            _context.Staff.AddRange(_list);
            _context.SaveChanges();
        }
        public static void AddPurchaseOrderData()
        {
            PurchaseOrder[] _list = 
            {
                new PurchaseOrder{Quantity=10,Price=50000,ProductID=2, SupplierID=3,PurchaseDate=new DateTime(2021,02,11)},
                new PurchaseOrder{Quantity=10,Price=5000,ProductID=3, SupplierID=4,PurchaseDate=new DateTime(2021,02,24)},
                new PurchaseOrder{Quantity=500000,Price=30000,ProductID=4, SupplierID=1,PurchaseDate=new DateTime(2021,03,14)},
                new PurchaseOrder{Quantity=1000,Price=500000,ProductID=6, SupplierID=4,PurchaseDate=new DateTime(2021,05,01)}
            };
            _context.PurchaseOrder.AddRange(_list);
            _context.SaveChanges();
        }
    }
}
