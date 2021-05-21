using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class Designation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

////Model: ProductCategory
//modelBuilder.Entity<ProductCategory>(productCategoryBuilder =>
//{
//    productCategoryBuilder.HasKey(productCategory => new { productCategory.ProductID, productCategory.CategoryID });

//    productCategoryBuilder
//    .HasOne(productCategory => productCategory.Product)
//    .WithMany(product => product.ProductCategories)
//    .HasForeignKey(productCategory => productCategory.ProductID);

//    productCategoryBuilder
//    .HasOne(productCategory => productCategory.Category)
//    .WithMany(category => category.ProductCategories)
//    .HasForeignKey(productCategory => productCategory.CategoryID);

//});

//Model: Product
//modelBuilder.Entity<Product>(productBuilder => {
//    productBuilder.HasKey(product => product.ID);
//    productBuilder.Property(product => product.Name).IsRequired().HasMaxLength(100);
//    productBuilder.Property(product => product.Code).IsRequired().HasMaxLength(100);
//    productBuilder.HasIndex(product => product.Code).IsUnique();
//    productBuilder.Property(product => product.Brand).HasMaxLength(50);
//    productBuilder.Property(product => product.Manufacturer).HasMaxLength(100).IsRequired();
//    productBuilder.Property(product => product.AvailableQuantity).HasDefaultValue(0);
//    productBuilder.HasOne(product => product.Inventory).WithOne(inventory => inventory.Product).HasForeignKey<Inventory>(inventory => inventory.ProductID);
//});

////Model: Category
//modelBuilder.Entity<Category>(categoryBuilder =>
//{
//    categoryBuilder.HasKey(category => category.ID);
//    categoryBuilder.Property(category => category.Name).IsRequired().HasMaxLength(100);
//    categoryBuilder.Property(category => category.Code).IsRequired().HasMaxLength(100);
//    categoryBuilder.HasIndex(category => category.Code).IsUnique();
//});




////Model: Inventory
//modelBuilder.Entity<Inventory>(inventoryBuilder => 
//{
//    inventoryBuilder.HasKey(inventory => inventory.ID);
//    inventoryBuilder.Property(inventory => inventory.OpeningStock).HasDefaultValue(0);
//    inventoryBuilder.Property(inventory => inventory.StockPurchased).HasDefaultValue(0);
//    inventoryBuilder.Property(inventory => inventory.StockSold).HasDefaultValue(0);

//});

////Model: Address
//modelBuilder.Entity<Address>(addressBuilder =>
//{
//    addressBuilder.HasKey(address => address.ID);
//    addressBuilder.Property(address => address.AddressLine1).IsRequired().HasMaxLength(100);
//    addressBuilder.Property(address => address.AddressLine2).HasMaxLength(100);
//    addressBuilder.Property(address => address.City).HasMaxLength(50);
//    addressBuilder.Property(address => address.State).HasMaxLength(50).IsRequired();
//    addressBuilder.Property(address => address.Country).HasMaxLength(60).IsRequired();
//    addressBuilder.Property(address => address.PinCode).HasMaxLength(6).IsRequired();
//});

////Model: Designation
//modelBuilder.Entity<Designation>(designationBuilder => {
//    designationBuilder.HasKey(designation => designation.ID);
//    designationBuilder.Property(designation => designation.Name).IsRequired().HasMaxLength(100);
//    designationBuilder.Property(designation => designation.Description).HasMaxLength(200);
//});


////Model: Staff
//modelBuilder.Entity<Staff>(staffBuilder => {
//    staffBuilder.HasKey(staff => staff.ID);
//    staffBuilder.Property(staff => staff.FirstName).IsRequired().HasMaxLength(128);
//    staffBuilder.Property(staff => staff.LastName).HasMaxLength(100);
//    staffBuilder.Property(staff => staff.PhoneNumber).IsRequired().HasMaxLength(10);
//    staffBuilder.Property(staff => staff.Email).HasMaxLength(50);
//    staffBuilder.Property(staff => staff.Gender).IsRequired();
//    staffBuilder.HasOne(staff => staff.Address).WithOne().HasForeignKey<Staff>(staff => staff.AddressID);
//    staffBuilder.HasOne(staff => staff.Designation).WithOne().HasForeignKey<Staff>(staff => staff.DesignationID);
//});

////Model: ProductPrice
//modelBuilder.Entity<ProductPrice>(productPriceBuilder => {
//    productPriceBuilder.Property(productPrice => productPrice.CostPrice).IsRequired();
//    productPriceBuilder.Property(productPrice => productPrice.SellingPrice).IsRequired();
//    productPriceBuilder.Property(productPrice => productPrice.Discount).HasDefaultValue(0);
//    productPriceBuilder.Property(productPrice => productPrice.PriceDate).IsRequired();
//    productPriceBuilder.HasOne(productPrice => productPrice.Product).WithOne().HasForeignKey<ProductPrice>(productPrice => productPrice.ProductID);
//});

////Model: Supplier
//modelBuilder.Entity<Supplier>(supplierBuilder => {
//    supplierBuilder.HasKey(supplier => supplier.ID);
//    supplierBuilder.Property(supplier => supplier.Name).IsRequired();
//    supplierBuilder.Property(supplier => supplier.PhoneNumber).IsRequired().HasMaxLength(10);
//    supplierBuilder.Property(supplier => supplier.Email).IsRequired();
//});

////Model: ProductSupplier
//modelBuilder.Entity<ProductSupplier>(productSupplierBuilder =>
//{
//    productSupplierBuilder.HasKey(productSupplier => new { productSupplier.ProductID, productSupplier.SupplierID });

//    productSupplierBuilder
//    .HasOne(productSupplier => productSupplier.Product)
//    .WithMany(product => product.ProductSuppliers)
//    .HasForeignKey(productSupplier => productSupplier.ProductID);

//    productSupplierBuilder
//    .HasOne(productSupplier => productSupplier.Supplier)
//    .WithMany(category => category.ProductSuppliers)
//    .HasForeignKey(productSupplier => productSupplier.SupplierID);
//});

//Model: PurchaseOrder
//modelBuilder.Entity<PurchaseOrder>(purchaseOrderBuilder =>
//{
//    purchaseOrderBuilder.HasKey(purchaseOrder => new { purchaseOrder.ProductID, purchaseOrder.SupplierID });
//    purchaseOrderBuilder.Property(purchaseOrder => purchaseOrder.Quantity).IsRequired();
//    purchaseOrderBuilder.Property(purchaseOrder => purchaseOrder.PurchaseDate).IsRequired();
//    purchaseOrderBuilder
//    .HasOne(purchaseOrder => purchaseOrder.ProductSupplier)
//    .WithOne()
//    .HasForeignKey<PurchaseOrder>(purchaseOrder => new { purchaseOrder.ProductID, purchaseOrder.SupplierID });

//});
