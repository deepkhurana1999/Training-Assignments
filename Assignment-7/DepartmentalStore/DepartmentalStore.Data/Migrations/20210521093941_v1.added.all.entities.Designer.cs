// <auto-generated />
using System;
using DepartmentalStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DepartmentalStore.Data.Migrations
{
    [DbContext(typeof(DepartmentalStoreContext))]
    [Migration("20210521093941_v1.added.all.entities")]
    partial class v1addedallentities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DepartmentalStore.Domain.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Category");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Designation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Designation");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Inventory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("OpeningStock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<int>("StockPurchased")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("StockSold")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("ID");

                    b.HasIndex("ProductID")
                        .IsUnique();

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.InventoryHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("InventoryID")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("InventoryID");

                    b.ToTable("InventoryHistory");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AvailableQuantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("Brand")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Product");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.ProductCategory", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryID")
                        .HasColumnType("integer");

                    b.HasKey("ProductID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.ProductPrice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<float>("CostPrice")
                        .HasColumnType("real");

                    b.Property<int>("Discount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("PriceDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<float>("SellingPrice")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductPrice");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.ProductSupplier", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<int>("SupplierID")
                        .HasColumnType("integer");

                    b.HasKey("ProductID", "SupplierID");

                    b.HasIndex("SupplierID");

                    b.ToTable("ProductSupplier");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.PurchaseOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("SupplierID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ProductID", "SupplierID")
                        .IsUnique();

                    b.ToTable("PurchaseOrder");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Staff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressID")
                        .HasColumnType("integer");

                    b.Property<int>("DesignationID")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<char>("Gender")
                        .HasColumnType("character(1)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.HasIndex("DesignationID");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Supplier", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressID")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Inventory", b =>
                {
                    b.HasOne("DepartmentalStore.Domain.Product", "Product")
                        .WithOne("Inventory")
                        .HasForeignKey("DepartmentalStore.Domain.Inventory", "ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.InventoryHistory", b =>
                {
                    b.HasOne("DepartmentalStore.Domain.Inventory", "Inventory")
                        .WithMany("InventoryHistory")
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.ProductCategory", b =>
                {
                    b.HasOne("DepartmentalStore.Domain.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DepartmentalStore.Domain.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.ProductPrice", b =>
                {
                    b.HasOne("DepartmentalStore.Domain.Product", "Product")
                        .WithMany("ProductPrices")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.ProductSupplier", b =>
                {
                    b.HasOne("DepartmentalStore.Domain.Product", "Product")
                        .WithMany("ProductSuppliers")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DepartmentalStore.Domain.Supplier", "Supplier")
                        .WithMany("ProductSuppliers")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.PurchaseOrder", b =>
                {
                    b.HasOne("DepartmentalStore.Domain.ProductSupplier", "ProductSupplier")
                        .WithOne()
                        .HasForeignKey("DepartmentalStore.Domain.PurchaseOrder", "ProductID", "SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductSupplier");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Staff", b =>
                {
                    b.HasOne("DepartmentalStore.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DepartmentalStore.Domain.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Designation");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Supplier", b =>
                {
                    b.HasOne("DepartmentalStore.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Inventory", b =>
                {
                    b.Navigation("InventoryHistory");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Product", b =>
                {
                    b.Navigation("Inventory");

                    b.Navigation("ProductCategories");

                    b.Navigation("ProductPrices");

                    b.Navigation("ProductSuppliers");
                });

            modelBuilder.Entity("DepartmentalStore.Domain.Supplier", b =>
                {
                    b.Navigation("ProductSuppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
