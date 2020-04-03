using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESINuevo.Data.Migrations
{
    public partial class addedListQuotationToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Quotation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_OrderId",
                table: "Quotation",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotation_Order_OrderId",
                table: "Quotation",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotation_Order_OrderId",
                table: "Quotation");

            migrationBuilder.DropIndex(
                name: "IX_Quotation_OrderId",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Quotation");
        }
    }
}
