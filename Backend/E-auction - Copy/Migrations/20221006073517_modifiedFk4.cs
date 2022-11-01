using Microsoft.EntityFrameworkCore.Migrations;

namespace E_auction.Migrations
{
    public partial class modifiedFk4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_SellerDetails_SellerDetailSellerID",
                table: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "SellerDetailSellerID",
                table: "ProductDetails",
                newName: "SellerIDFK");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_SellerDetailSellerID",
                table: "ProductDetails",
                newName: "IX_ProductDetails_SellerIDFK");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_SellerDetails_SellerIDFK",
                table: "ProductDetails",
                column: "SellerIDFK",
                principalTable: "SellerDetails",
                principalColumn: "SellerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_SellerDetails_SellerIDFK",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "SellerIDFK",
                table: "ProductDetails",
                newName: "SellerDetailSellerID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_SellerIDFK",
                table: "ProductDetails",
                newName: "IX_ProductDetails_SellerDetailSellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_SellerDetails_SellerDetailSellerID",
                table: "ProductDetails",
                column: "SellerDetailSellerID",
                principalTable: "SellerDetails",
                principalColumn: "SellerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
