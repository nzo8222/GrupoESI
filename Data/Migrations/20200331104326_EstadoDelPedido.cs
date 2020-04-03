using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESINuevo.Data.Migrations
{
    public partial class EstadoDelPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstadoDelPedido",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoDelPedido",
                table: "Order");
        }
    }
}
