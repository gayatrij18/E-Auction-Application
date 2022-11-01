using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_auction.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellerDetails",
                columns: table => new
                {
                    SellerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerDetails", x => x.SellerID);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BidEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidsPlaced = table.Column<bool>(type: "bit", nullable: false),
                    buyerId = table.Column<int>(type: "int", nullable: true),
                    SellerDetailSellerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_BuyerDetails_buyerId",
                        column: x => x.buyerId,
                        principalTable: "BuyerDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetails_SellerDetails_SellerDetailSellerID",
                        column: x => x.SellerDetailSellerID,
                        principalTable: "SellerDetails",
                        principalColumn: "SellerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_Buyer_Details",
                columns: table => new
                {
                    ProductBuyerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerDetailId = table.Column<int>(type: "int", nullable: true),
                    ProductDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Buyer_Details", x => x.ProductBuyerID);
                    table.ForeignKey(
                        name: "FK_Product_Buyer_Details_BuyerDetails_BuyerDetailId",
                        column: x => x.BuyerDetailId,
                        principalTable: "BuyerDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Buyer_Details_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_Seller_Details",
                columns: table => new
                {
                    ReferenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDetailId = table.Column<int>(type: "int", nullable: true),
                    SellerDetailSellerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Seller_Details", x => x.ReferenceID);
                    table.ForeignKey(
                        name: "FK_Product_Seller_Details_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Seller_Details_SellerDetails_SellerDetailSellerID",
                        column: x => x.SellerDetailSellerID,
                        principalTable: "SellerDetails",
                        principalColumn: "SellerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Buyer_Details_BuyerDetailId",
                table: "Product_Buyer_Details",
                column: "BuyerDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Buyer_Details_ProductDetailId",
                table: "Product_Buyer_Details",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Seller_Details_ProductDetailId",
                table: "Product_Seller_Details",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Seller_Details_SellerDetailSellerID",
                table: "Product_Seller_Details",
                column: "SellerDetailSellerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_buyerId",
                table: "ProductDetails",
                column: "buyerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_SellerDetailSellerID",
                table: "ProductDetails",
                column: "SellerDetailSellerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Buyer_Details");

            migrationBuilder.DropTable(
                name: "Product_Seller_Details");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "BuyerDetails");

            migrationBuilder.DropTable(
                name: "SellerDetails");
        }
    }
}
