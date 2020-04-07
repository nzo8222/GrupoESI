using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESINuevo.Data.Migrations
{
    public partial class seAgregoLaPropiedadQuotationModelAlModeloTarea2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Quotation_QuotationId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_QuotationId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "QuotationId",
                table: "Task");

            migrationBuilder.AddColumn<int>(
                name: "QuotationModelId",
                table: "Task",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_QuotationModelId",
                table: "Task",
                column: "QuotationModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Quotation_QuotationModelId",
                table: "Task",
                column: "QuotationModelId",
                principalTable: "Quotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Quotation_QuotationModelId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_QuotationModelId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "QuotationModelId",
                table: "Task");

            migrationBuilder.AddColumn<int>(
                name: "QuotationId",
                table: "Task",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_QuotationId",
                table: "Task",
                column: "QuotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Quotation_QuotationId",
                table: "Task",
                column: "QuotationId",
                principalTable: "Quotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
