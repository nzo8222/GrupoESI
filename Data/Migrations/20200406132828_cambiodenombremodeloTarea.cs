using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESINuevo.Data.Migrations
{
    public partial class cambiodenombremodeloTarea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsModelId",
                table: "Quotation",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsId",
                table: "Quotation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_OrderDetailsId",
                table: "Quotation",
                column: "OrderDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotation_OrderDetails_OrderDetailsId",
                table: "Quotation",
                column: "OrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
