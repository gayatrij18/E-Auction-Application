﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace E_auction.Migrations
{
    public partial class modifiedFk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_SellerDetails_SellerDetailSellerID",
                table: "ProductDetails");

            migrationBuilder.AlterColumn<int>(
                name: "SellerDetailSellerID",
                table: "ProductDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "SellerDetailSellerID",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_SellerDetails_SellerDetailSellerID",
                table: "ProductDetails",
                column: "SellerDetailSellerID",
                principalTable: "SellerDetails",
                principalColumn: "SellerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
