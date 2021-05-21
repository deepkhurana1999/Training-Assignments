using DepartmentalStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DepartmentalStore.Data
{
    public class DepartmentalStoreContext: DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryHistory> InventoryHistory { get; set; }


        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name
            && level == LogLevel.Information).AddConsole();
        }
        );

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory).EnableSensitiveDataLogging().UseNpgsql(@"Host=localhost;Database=DepartmentalStoreDB3;Username=postgres;Password=Password12@");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Model: ProductSupplier
            modelBuilder.Entity<ProductSupplier>(productSupplierBuilder =>
            {
                productSupplierBuilder.HasKey(productSupplier => new { productSupplier.ProductID, productSupplier.SupplierID });

                productSupplierBuilder
                .HasOne(productSupplier => productSupplier.Product)
                .WithMany(product => product.ProductSuppliers)
                .HasForeignKey(productSupplier => productSupplier.ProductID);

                productSupplierBuilder
                .HasOne(productSupplier => productSupplier.Supplier)
                .WithMany(category => category.ProductSuppliers)
                .HasForeignKey(productSupplier => productSupplier.SupplierID);
            });

            //Model: ProductCategory
            modelBuilder.Entity<ProductCategory>(productCategoryBuilder =>
            {
                productCategoryBuilder.HasKey(productCategory => new { productCategory.ProductID, productCategory.CategoryID });

                productCategoryBuilder
                .HasOne(productCategory => productCategory.Product)
                .WithMany(product => product.ProductCategories)
                .HasForeignKey(productCategory => productCategory.ProductID);

                productCategoryBuilder
                .HasOne(productCategory => productCategory.Category)
                .WithMany(category => category.ProductCategories)
                .HasForeignKey(productCategory => productCategory.CategoryID);

            });

            //Model: Product
            modelBuilder.Entity<Product>(productBuilder => {
                productBuilder.HasKey(product => product.ID);
                productBuilder.Property(product => product.Name).IsRequired().HasMaxLength(100);
                productBuilder.Property(product => product.Code).IsRequired().HasMaxLength(100);
                productBuilder.HasIndex(product => product.Code).IsUnique();
                productBuilder.Property(product => product.Brand).HasMaxLength(50);
                productBuilder.Property(product => product.Manufacturer).HasMaxLength(100).IsRequired();
                productBuilder.Property(product => product.AvailableQuantity).HasDefaultValue(0);
                productBuilder.HasOne(product => product.Inventory).WithOne(inventory => inventory.Product);
                productBuilder.HasMany(product => product.ProductSuppliers).WithOne(productSupplier => productSupplier.Product);
                productBuilder.HasMany(product => product.ProductCategories).WithOne(productCategory => productCategory.Product);
                productBuilder.HasMany(product => product.ProductPrices).WithOne(inventory => inventory.Product);
            });

            //Model: Category
            modelBuilder.Entity<Category>(categoryBuilder =>
            {
                categoryBuilder.HasKey(category => category.ID);
                categoryBuilder.Property(category => category.Name).IsRequired().HasMaxLength(100);
                categoryBuilder.Property(category => category.Code).IsRequired().HasMaxLength(100);
                categoryBuilder.HasIndex(category => category.Code).IsUnique();
                categoryBuilder.HasMany(category => category.ProductCategories).WithOne(productCategory => productCategory.Category);
            });

            //Model: Supplier
            modelBuilder.Entity<Supplier>(supplierBuilder =>
            {
                supplierBuilder.HasKey(supplier => supplier.ID);
                supplierBuilder.Property(supplier => supplier.Name).IsRequired().HasMaxLength(100);
                supplierBuilder.Property(supplier => supplier.PhoneNumber).IsRequired().HasMaxLength(10);
                supplierBuilder.Property(supplier => supplier.Email).IsRequired();
                supplierBuilder.HasMany(supplier => supplier.ProductSuppliers).WithOne(productSupplier => productSupplier.Supplier);
                supplierBuilder.HasOne(supplier => supplier.Address).WithMany().HasForeignKey(supplier => supplier.AddressID);
                supplierBuilder.Property(supplier => supplier.AddressID).IsRequired();
            });

            //Model: Inventory
            modelBuilder.Entity<Inventory>(inventoryBuilder =>
            {
                inventoryBuilder.HasKey(inventory => inventory.ID);
                inventoryBuilder.Property(inventory => inventory.OpeningStock).HasDefaultValue(0);
                inventoryBuilder.Property(inventory => inventory.StockPurchased).HasDefaultValue(0);
                inventoryBuilder.Property(inventory => inventory.StockSold).HasDefaultValue(0);
                inventoryBuilder.HasOne(inventory => inventory.Product).WithOne(product => product.Inventory).HasForeignKey<Inventory>(inventory => inventory.ProductID);
                inventoryBuilder.Property(inventory => inventory.ProductID).IsRequired();
                inventoryBuilder.HasIndex(inventory => inventory.ProductID).IsUnique();
                inventoryBuilder.HasMany(inventory => inventory.InventoryHistory).WithOne(inventoryHistory => inventoryHistory.Inventory);
            });

            //Model: Address
            modelBuilder.Entity<Address>(addressBuilder =>
            {
                addressBuilder.HasKey(address => address.ID);
                addressBuilder.Property(address => address.AddressLine1).IsRequired().HasMaxLength(100);
                addressBuilder.Property(address => address.AddressLine2).HasMaxLength(100);
                addressBuilder.Property(address => address.City).HasMaxLength(50);
                addressBuilder.Property(address => address.State).HasMaxLength(50).IsRequired();
                addressBuilder.Property(address => address.Country).HasMaxLength(60).IsRequired();
                addressBuilder.Property(address => address.PinCode).HasMaxLength(6).IsRequired();
            });

            //Model: Designation
            modelBuilder.Entity<Designation>(designationBuilder =>
            {
                designationBuilder.HasKey(designation => designation.ID);
                designationBuilder.Property(designation => designation.Name).IsRequired().HasMaxLength(100);
                designationBuilder.HasIndex(designation => designation.Name).IsUnique();
                designationBuilder.Property(designation => designation.Description).HasMaxLength(200);
            });


            //Model: Staff
            modelBuilder.Entity<Staff>(staffBuilder =>
            {
                staffBuilder.HasKey(staff => staff.ID);
                staffBuilder.Property(staff => staff.FirstName).IsRequired().HasMaxLength(128);
                staffBuilder.Property(staff => staff.LastName).HasMaxLength(100);
                staffBuilder.Property(staff => staff.PhoneNumber).IsRequired().HasMaxLength(10);
                staffBuilder.Property(staff => staff.Email).HasMaxLength(50);
                staffBuilder.Property(staff => staff.Gender).IsRequired();
                staffBuilder.HasOne(staff => staff.Address).WithMany().HasForeignKey(staff => staff.AddressID);
                staffBuilder.HasOne(staff => staff.Designation).WithMany().HasForeignKey(staff => staff.DesignationID);
                staffBuilder.Property(staff => staff.AddressID).IsRequired();
                staffBuilder.Property(staff => staff.DesignationID).IsRequired();
            });

            ////Model: ProductPrice
            modelBuilder.Entity<ProductPrice>(productPriceBuilder =>
            {
                productPriceBuilder.HasKey(productPrice => productPrice.ID);
                productPriceBuilder.Property(productPrice => productPrice.CostPrice).IsRequired();
                productPriceBuilder.Property(productPrice => productPrice.SellingPrice).IsRequired();
                productPriceBuilder.Property(productPrice => productPrice.Discount).HasDefaultValue(0);
                productPriceBuilder.Property(productPrice => productPrice.PriceDate).IsRequired();
                productPriceBuilder.HasOne(productPrice => productPrice.Product).WithMany(product => product.ProductPrices).HasForeignKey(productPrice => productPrice.ProductID);
                productPriceBuilder.Property(productPrice => productPrice.ProductID).IsRequired();
            });

            //Model: PurchaseOrder
            modelBuilder.Entity<PurchaseOrder>(purchaseOrderBuilder =>
            {
                purchaseOrderBuilder.HasKey(purchaseOrder => purchaseOrder.ID);
                purchaseOrderBuilder.Property(purchaseOrder => purchaseOrder.Quantity).IsRequired();
                purchaseOrderBuilder.Property(purchaseOrder => purchaseOrder.PurchaseDate).IsRequired();
                purchaseOrderBuilder
                .HasOne(purchaseOrder => purchaseOrder.ProductSupplier)
                .WithOne()
                .HasForeignKey<PurchaseOrder>(purchaseOrder => new { purchaseOrder.ProductID, purchaseOrder.SupplierID });
                purchaseOrderBuilder.Property(purchaseOrder => purchaseOrder.ProductID).IsRequired();
                purchaseOrderBuilder.Property(purchaseOrder => purchaseOrder.SupplierID).IsRequired();
                purchaseOrderBuilder.HasIndex(purchaseOrder => new { purchaseOrder.ProductID, purchaseOrder.SupplierID }).IsUnique();
            });

            //Model: InventoryHistory
            modelBuilder.Entity<InventoryHistory>(inventoryHistoryBuilder =>
            {
                inventoryHistoryBuilder.HasKey(inventoryHistory => inventoryHistory.ID);
                inventoryHistoryBuilder.Property(inventoryHistory => inventoryHistory.Quantity).IsRequired();
                inventoryHistoryBuilder.Property(inventoryHistory => inventoryHistory.InventoryID).IsRequired();
                inventoryHistoryBuilder.HasOne(inventoryHistory => inventoryHistory.Inventory).WithMany(inventory => inventory.InventoryHistory).HasForeignKey(inventoryHistory => inventoryHistory.InventoryID);
            });
        }
    }
}
