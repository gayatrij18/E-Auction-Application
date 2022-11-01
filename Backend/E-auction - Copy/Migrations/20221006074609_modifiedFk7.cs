using Microsoft.EntityFrameworkCore.Migrations;

namespace E_auction.Migrations
{
    public partial class modifiedFk7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_SellerDetails_SellerIDFK",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_SellerIDFK",
                table: "ProductDetails");

            migrationBuilder.AlterColumn<int>(
                name: "SellerIDFK",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerDetailSellerID",
                table: "ProductDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_SellerDetailSellerID",
                table: "ProductDetails",
                column: "SellerDetailSellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_SellerDetails_SellerDetailSellerID",
                table: "ProductDetails",
                column: "SellerDetailSellerID",
                principalTable: "SellerDetails",
                principalColumn: "SellerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_SellerDetails_SellerDetailSellerID",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_SellerDetailSellerID",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "SellerDetailSellerID",
                table: "ProductDetails");

            migrationBuilder.AlterColumn<int>(
                name: "SellerIDFK",
                table: "ProductDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_SellerIDFK",
                table: "ProductDetails",
                column: "SellerIDFK");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_SellerDetails_SellerIDFK",
                table: "ProductDetails",
                column: "SellerIDFK",
                principalTable: "SellerDetails",
                principalColumn: "SellerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
