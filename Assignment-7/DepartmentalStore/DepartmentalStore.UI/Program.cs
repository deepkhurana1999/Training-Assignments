using DepartmentalStore.Domain;
using System;
using System.Collections.Generic;

namespace DepartmentalStore.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DBOperation.SeedData();
            //DBOperation.ShowData();

            //r//DBOperation.AddProductData();
            //r//DBOperation.AddCategoryData();

            //r//DBOperation.AddProductCategoryData();
            //r//DBOperation.AddProductPrice();
            //r//DBOperation.AddInventoryData();

            //r//DBOperation.AddAddressData();

            //r//DBOperation.AddSupplierData();
            //r//DBOperation.AddProductSupplierData();
            //r//DBOperation.AddDesignationData();
            //r//DBOperation.AddStaffData();
            //r//DBOperation.AddPurchaseOrderData();

            //Query Staff using Name
            QuerySolution.QueryStaff(staff => staff.FirstName == "Person2");
            //Query Staff using PhoneNumber
            QuerySolution.QueryStaff(staff => staff.PhoneNumber == "1234567890");
            //Query Staff using Name or PhoneNumber
            QuerySolution.QueryStaff(staff => staff.FirstName == "Person1" || staff.PhoneNumber == "1234567890");
            //Query Staff using Desgination
            QuerySolution.QueryStaffWithJoin<Designation>(staff=> staff.Designation,staff => staff.Designation.Name == "Helper");

            //Query Product using Name
            QuerySolution.QueryProduct(product => product.Name == "Lenovo P2");
            //Query Product with Category
            QuerySolution.QueryProductWithCategory();
            //Query Product with IN Stock
            QuerySolution.QueryProduct(product => product.AvailableQuantity>0);
            //Query Product with Out of Stock
            QuerySolution.QueryProduct(product => product.AvailableQuantity == 0);
            //Query to Count product with out of stock
            QuerySolution.QueryProductWithPrice();
            //Query to count number of products of a category
            QuerySolution.QueryCategoryWithProductCount();
            //Query to display category with no. of products in DESC
            QuerySolution.QueryCategoryWithProductDesc();

            //Query Supplier using Name
            QuerySolution.QuerySupplier(supplier => supplier.Name.Contains("Njoy-Buying"));
            //Query Supplier using Phone
            QuerySolution.QuerySupplier(supplier => supplier.PhoneNumber == "7629520971");
            //Query Supplier using Email
            QuerySolution.QuerySupplier(supplier => supplier.Email == "n@gmail.com");
            //Query Supplier using Address
            QuerySolution.QuerySupplierwithAddress();

            //Query Product with Supplier using Name
            QuerySolution.QueryProductwithSupplierusingProductName();
            //Query Product with Supplier using Name
            QuerySolution.QueryProductwithSupplierusingSupplierName();
            //Query Product with Supplier using Name
            QuerySolution.QueryProductwithSupplierusingProductCode();
            //Query Product with Supplier using SuppliedDate
            QuerySolution.QueryProductwithSupplierusingSuppliedDate();
            //Query Product with Supplier using Inventory > 10
            QuerySolution.QueryProductwithSupplierusingInventory();

        }
    }
}
