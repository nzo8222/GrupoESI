using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESINuevo.Migrations
{
    public partial class addStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Quotation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderDetails");
        }
    }
}
