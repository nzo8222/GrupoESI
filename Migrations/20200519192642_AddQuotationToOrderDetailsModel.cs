using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESINuevo.Migrations
{
    public partial class AddQuotationToOrderDetailsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotation_OrderDetails_OrderDetailsModelId",
                table: "Quotation");

            migrationBuilder.DropIndex(
                name: "IX_Quotation_OrderDetailsModelId",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "OrderDetailsModelId",
                table: "Quotation");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderDetailsId",
                table: "Quotation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_OrderDetailsId",
                table: "Quotation",
                column: "OrderDetailsId",
                unique: true,
                filter: "[OrderDetailsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotation_OrderDetails_OrderDetailsId",
                table: "Quotation",
                column: "OrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotation_OrderDetails_OrderDetailsId",
                table: "Quotation");

            migrationBuilder.DropIndex(
                name: "IX_Quotation_OrderDetailsId",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "OrderDetailsId",
                table: "Quotation");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderDetailsModelId",
                table: "Quotation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_OrderDetailsModelId",
                table: "Quotation",
                column: "OrderDetailsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotation_OrderDetails_OrderDetailsModelId",
                table: "Quotation",
                column: "OrderDetailsModelId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
