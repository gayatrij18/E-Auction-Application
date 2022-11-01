using Microsoft.EntityFrameworkCore.Migrations;

namespace E_auction.Migrations
{
    public partial class initialMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BuyerDetails_ProductId",
                table: "BuyerDetails");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerDetails_ProductId",
                table: "BuyerDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BuyerDetails_ProductId",
                table: "BuyerDetails");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerDetails_ProductId",
                table: "BuyerDetails",
                column: "ProductId",
                unique: true);
        }
    }
}
