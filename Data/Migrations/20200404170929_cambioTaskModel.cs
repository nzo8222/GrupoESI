using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESINuevo.Data.Migrations
{
    public partial class cambioTaskModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Task_TaskId",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Material_TaskId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Material");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Task",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Task",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskModelId",
                table: "Material",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_TaskModelId",
                table: "Material",
                column: "TaskModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Task_TaskModelId",
                table: "Material",
                column: "TaskModelId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Task_TaskModelId",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Material_TaskModelId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TaskModelId",
                table: "Material");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Material",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_TaskId",
                table: "Material",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Task_TaskId",
                table: "Material",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
