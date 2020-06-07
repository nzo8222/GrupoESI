using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESINuevo.Migrations
{
    public partial class changePicIDd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
               name: "PK_Picture",
               table: "Picture");
            migrationBuilder.DropColumn(
                 name: "PictureId",
                table: "Picture");
            migrationBuilder.AddColumn<Guid>(
                nullable: false,
                 name: "PictureId",
                table: "Picture");
            migrationBuilder.AddPrimaryKey(
                name: "PK_Picture",
                table: "Picture",
                column: "PictureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PictureId",
                table: "Picture",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
