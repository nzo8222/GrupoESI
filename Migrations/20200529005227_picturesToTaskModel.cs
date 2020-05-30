using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESINuevo.Migrations
{
    public partial class picturesToTaskModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Quotation_QuotationId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_QuotationId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "QuotationId",
                table: "Picture");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskModelId",
                table: "Picture",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_TaskModelId",
                table: "Picture",
                column: "TaskModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Task_TaskModelId",
                table: "Picture",
                column: "TaskModelId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Task_TaskModelId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_TaskModelId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "TaskModelId",
                table: "Picture");

            migrationBuilder.AddColumn<Guid>(
                name: "QuotationId",
                table: "Picture",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_QuotationId",
                table: "Picture",
                column: "QuotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Quotation_QuotationId",
                table: "Picture",
                column: "QuotationId",
                principalTable: "Quotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
