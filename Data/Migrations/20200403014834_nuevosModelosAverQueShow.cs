using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESINuevo.Data.Migrations
{
    public partial class nuevosModelosAverQueShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Task_TaskModelId",
                table: "Material");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ServiceModel_ServiceId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotation_Order_OrderId",
                table: "Quotation");

            migrationBuilder.DropIndex(
                name: "IX_Quotation_OrderId",
                table: "Quotation");

            migrationBuilder.DropIndex(
                name: "IX_Order_ServiceId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Material_TaskModelId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TaskModelId",
                table: "Material");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ServiceModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ServiceModel",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "serviceTypeId",
                table: "ServiceModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsId",
                table: "Quotation",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Material",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceID = table.Column<int>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    Cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ServiceModel_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "ServiceModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModel_serviceTypeId",
                table: "ServiceModel",
                column: "serviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_OrderDetailsId",
                table: "Quotation",
                column: "OrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_TaskId",
                table: "Material",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ServiceID",
                table: "OrderDetails",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Task_TaskId",
                table: "Material",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotation_OrderDetails_OrderDetailsId",
                table: "Quotation",
                column: "OrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceModel_ServiceType_serviceTypeId",
                table: "ServiceModel",
                column: "serviceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Task_TaskId",
                table: "Material");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotation_OrderDetails_OrderDetailsId",
                table: "Quotation");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceModel_ServiceType_serviceTypeId",
                table: "ServiceModel");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropIndex(
                name: "IX_ServiceModel_serviceTypeId",
                table: "ServiceModel");

            migrationBuilder.DropIndex(
                name: "IX_Quotation_OrderDetailsId",
                table: "Quotation");

            migrationBuilder.DropIndex(
                name: "IX_Material_TaskId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "serviceTypeId",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "OrderDetailsId",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Material");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "ServiceModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "ServiceModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "ServiceModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Quotation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskModelId",
                table: "Material",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_OrderId",
                table: "Quotation",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ServiceId",
                table: "Order",
                column: "ServiceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ServiceModel_ServiceId",
                table: "Order",
                column: "ServiceId",
                principalTable: "ServiceModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotation_Order_OrderId",
                table: "Quotation",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
