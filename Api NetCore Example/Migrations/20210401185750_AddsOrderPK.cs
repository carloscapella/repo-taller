using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_NetCore_Example.Migrations
{
    public partial class AddsOrderPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Customers_CustomerId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_CustomerId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "OrderItem");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Order",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customers_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customers_CustomerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Order");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "OrderItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CustomerId",
                table: "OrderItem",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Customers_CustomerId",
                table: "OrderItem",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
