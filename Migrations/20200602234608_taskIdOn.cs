using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESINuevo.Migrations
{
    public partial class taskIdOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Task_TaskModelId",
                table: "Picture");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskModelId",
                table: "Picture",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Task_TaskModelId",
                table: "Picture",
                column: "TaskModelId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Task_TaskModelId",
                table: "Picture");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskModelId",
                table: "Picture",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Task_TaskModelId",
                table: "Picture",
                column: "TaskModelId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
