using Microsoft.EntityFrameworkCore.Migrations;

namespace E_auction.Migrations
{
    public partial class modifiedFk6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "ProductDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
