﻿// <auto-generated />
using System;
using E_auction.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_auction.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20221001101712_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E_auction.Data.Models.BuyerDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pincode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BuyerDetails");
                });

            modelBuilder.Entity("E_auction.Data.Models.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BidEndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("BidsPlaced")
                        .HasColumnType("bit");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DetailedDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SellerDetailSellerID")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("StartingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("buyerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SellerDetailSellerID");

                    b.HasIndex("buyerId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("E_auction.Data.Models.Product_Buyer", b =>
                {
                    b.Property<int>("ProductBuyerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BuyerDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductDetailId")
                        .HasColumnType("int");

                    b.HasKey("ProductBuyerID");

                    b.HasIndex("BuyerDetailId");

                    b.HasIndex("ProductDetailId");

                    b.ToTable("Product_Buyer_Details");
                });

            modelBuilder.Entity("E_auction.Data.Models.Product_Seller", b =>
                {
                    b.Property<int>("ReferenceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("SellerDetailSellerID")
                        .HasColumnType("int");

                    b.HasKey("ReferenceID");

                    b.HasIndex("ProductDetailId");

                    b.HasIndex("SellerDetailSellerID");

                    b.ToTable("Product_Seller_Details");
                });

            modelBuilder.Entity("E_auction.Data.Models.SellerDetail", b =>
                {
                    b.Property<int>("SellerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SellerID");

                    b.ToTable("SellerDetails");
                });

            modelBuilder.Entity("E_auction.Data.Models.ProductDetail", b =>
                {
                    b.HasOne("E_auction.Data.Models.SellerDetail", null)
                        .WithMany("ProductDetails")
                        .HasForeignKey("SellerDetailSellerID");

                    b.HasOne("E_auction.Data.Models.BuyerDetail", "buyer")
                        .WithMany("ProductDetail")
                        .HasForeignKey("buyerId");

                    b.Navigation("buyer");
                });

            modelBuilder.Entity("E_auction.Data.Models.Product_Buyer", b =>
                {
                    b.HasOne("E_auction.Data.Models.BuyerDetail", "BuyerDetail")
                        .WithMany()
                        .HasForeignKey("BuyerDetailId");

                    b.HasOne("E_auction.Data.Models.ProductDetail", "ProductDetail")
                        .WithMany()
                        .HasForeignKey("ProductDetailId");

                    b.Navigation("BuyerDetail");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("E_auction.Data.Models.Product_Seller", b =>
                {
                    b.HasOne("E_auction.Data.Models.ProductDetail", "ProductDetail")
                        .WithMany()
                        .HasForeignKey("ProductDetailId");

                    b.HasOne("E_auction.Data.Models.SellerDetail", "SellerDetail")
                        .WithMany()
                        .HasForeignKey("SellerDetailSellerID");

                    b.Navigation("ProductDetail");

                    b.Navigation("SellerDetail");
                });

            modelBuilder.Entity("E_auction.Data.Models.BuyerDetail", b =>
                {
                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("E_auction.Data.Models.SellerDetail", b =>
                {
                    b.Navigation("ProductDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
