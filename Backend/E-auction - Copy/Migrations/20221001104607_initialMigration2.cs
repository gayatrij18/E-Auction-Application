using Microsoft.EntityFrameworkCore.Migrations;

namespace E_auction.Migrations
{
    public partial class initialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_BuyerDetails_buyerId",
                table: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Product_Buyer_Details");

            migrationBuilder.DropTable(
                name: "Product_Seller_Details");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_buyerId",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "buyerId",
                table: "ProductDetails");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerDetails_ProductId",
                table: "BuyerDetails",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerDetails_ProductDetails_ProductId",
                table: "BuyerDetails",
                column: "ProductId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerDetails_ProductDetails_ProductId",
                table: "BuyerDetails");

            migrationBuilder.DropIndex(
                name: "IX_BuyerDetails_ProductId",
                table: "BuyerDetails");

            migrationBuilder.AddColumn<int>(
                name: "buyerId",
                table: "ProductDetails",
                type: "int",
                nullable: true);

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
                name: "IX_ProductDetails_buyerId",
                table: "ProductDetails",
                column: "buyerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_BuyerDetails_buyerId",
                table: "ProductDetails",
                column: "buyerId",
                principalTable: "BuyerDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
