﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warehouse.Persistence;

namespace Warehouse.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211105123128_GenerateTables")]
    partial class GenerateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Warehouse.Core.Models.Merchant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("city");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("merchants");
                });

            modelBuilder.Entity("Warehouse.Core.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int")
                        .HasColumnName("technician_id");

                    b.Property<double>("Total")
                        .HasColumnType("double")
                        .HasColumnName("total");

                    b.HasKey("Id");

                    b.HasIndex("TechnicianId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Warehouse.Core.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<double>("SubTotal")
                        .HasColumnType("double")
                        .HasColumnName("sub_total");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("order_details");
                });

            modelBuilder.Entity("Warehouse.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("MerchantId")
                        .HasColumnType("int")
                        .HasColumnName("merchant_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double")
                        .HasColumnName("price");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("unit");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Warehouse.Core.Models.ProductPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("file_name");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("product_photos");
                });

            modelBuilder.Entity("Warehouse.Core.Models.Supply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("supplies");
                });

            modelBuilder.Entity("Warehouse.Core.Models.SupplyEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("stock_entries");
                });

            modelBuilder.Entity("Warehouse.Core.Models.Technician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<double>("Balance")
                        .HasColumnType("double")
                        .HasColumnName("balance");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("technicians");
                });

            modelBuilder.Entity("Warehouse.Core.Models.TechnicianBalanceEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<double>("Amount")
                        .HasColumnType("double")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int")
                        .HasColumnName("technician_id");

                    b.HasKey("Id");

                    b.HasIndex("TechnicianId");

                    b.ToTable("technician_balance_entries");
                });

            modelBuilder.Entity("Warehouse.Core.Models.TechnicianPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("file_name");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int")
                        .HasColumnName("technician_id");

                    b.HasKey("Id");

                    b.HasIndex("TechnicianId");

                    b.ToTable("technician_photos");
                });

            modelBuilder.Entity("Warehouse.Core.Models.Order", b =>
                {
                    b.HasOne("Warehouse.Core.Models.Technician", "Technician")
                        .WithMany("Orders")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("Warehouse.Core.Models.OrderDetail", b =>
                {
                    b.HasOne("Warehouse.Core.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.Core.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Warehouse.Core.Models.Product", b =>
                {
                    b.HasOne("Warehouse.Core.Models.Merchant", "Merchant")
                        .WithMany("Products")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("Warehouse.Core.Models.ProductPhoto", b =>
                {
                    b.HasOne("Warehouse.Core.Models.Product", null)
                        .WithMany("Photos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Warehouse.Core.Models.Supply", b =>
                {
                    b.HasOne("Warehouse.Core.Models.Product", "Product")
                        .WithMany("Supplies")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Warehouse.Core.Models.SupplyEntry", b =>
                {
                    b.HasOne("Warehouse.Core.Models.Product", "Product")
                        .WithMany("SupplyEntries")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Warehouse.Core.Models.TechnicianBalanceEntry", b =>
                {
                    b.HasOne("Warehouse.Core.Models.Technician", "Technician")
                        .WithMany("BalanceEntries")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("Warehouse.Core.Models.TechnicianPhoto", b =>
                {
                    b.HasOne("Warehouse.Core.Models.Technician", null)
                        .WithMany("Photos")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Warehouse.Core.Models.Merchant", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Warehouse.Core.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Warehouse.Core.Models.Product", b =>
                {
                    b.Navigation("Photos");

                    b.Navigation("Supplies");

                    b.Navigation("SupplyEntries");
                });

            modelBuilder.Entity("Warehouse.Core.Models.Technician", b =>
                {
                    b.Navigation("BalanceEntries");

                    b.Navigation("Orders");

                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
