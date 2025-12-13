using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnit_Products_ProductId",
                table: "ProductUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_Products_ProductId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Suppliers_SupplierId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetails_Products_ProductId",
                table: "SalesOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetails_SalesOrders_SalesOrderId",
                table: "SalesOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Customers_CustomerId",
                table: "SalesOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUnit",
                table: "ProductUnit");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductUnit",
                newName: "ProductUnits");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "ProductUnits",
                newName: "SalePrice");

            migrationBuilder.RenameColumn(
                name: "QuantityPerUnit",
                table: "ProductUnits",
                newName: "UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUnit_ProductId",
                table: "ProductUnits",
                newName: "IX_ProductUnits_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "ProductUnitId",
                table: "SalesOrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductUnitId1",
                table: "SalesOrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductUnitId",
                table: "PurchaseOrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductUnitId1",
                table: "PurchaseOrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Factor",
                table: "ProductUnits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUnits",
                table: "ProductUnits",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "قطعة" },
                    { 2, "علبة" },
                    { 3, "كرتونة" },
                    { 4, "كيلو" },
                    { 5, "لتر" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetails_ProductUnitId",
                table: "SalesOrderDetails",
                column: "ProductUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetails_ProductUnitId1",
                table: "SalesOrderDetails",
                column: "ProductUnitId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetails_ProductUnitId",
                table: "PurchaseOrderDetails",
                column: "ProductUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetails_ProductUnitId1",
                table: "PurchaseOrderDetails",
                column: "ProductUnitId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUnits_UnitId",
                table: "ProductUnits",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnits_Products_ProductId",
                table: "ProductUnits",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnits_Units_UnitId",
                table: "ProductUnits",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_ProductUnits_ProductUnitId",
                table: "PurchaseOrderDetails",
                column: "ProductUnitId",
                principalTable: "ProductUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_ProductUnits_ProductUnitId1",
                table: "PurchaseOrderDetails",
                column: "ProductUnitId1",
                principalTable: "ProductUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_Products_ProductId",
                table: "PurchaseOrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Suppliers_SupplierId",
                table: "PurchaseOrders",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetails_ProductUnits_ProductUnitId",
                table: "SalesOrderDetails",
                column: "ProductUnitId",
                principalTable: "ProductUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetails_ProductUnits_ProductUnitId1",
                table: "SalesOrderDetails",
                column: "ProductUnitId1",
                principalTable: "ProductUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetails_Products_ProductId",
                table: "SalesOrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetails_SalesOrders_SalesOrderId",
                table: "SalesOrderDetails",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Customers_CustomerId",
                table: "SalesOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnits_Products_ProductId",
                table: "ProductUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnits_Units_UnitId",
                table: "ProductUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_ProductUnits_ProductUnitId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_ProductUnits_ProductUnitId1",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_Products_ProductId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Suppliers_SupplierId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetails_ProductUnits_ProductUnitId",
                table: "SalesOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetails_ProductUnits_ProductUnitId1",
                table: "SalesOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetails_Products_ProductId",
                table: "SalesOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetails_SalesOrders_SalesOrderId",
                table: "SalesOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Customers_CustomerId",
                table: "SalesOrders");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderDetails_ProductUnitId",
                table: "SalesOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderDetails_ProductUnitId1",
                table: "SalesOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderDetails_ProductUnitId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderDetails_ProductUnitId1",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUnits",
                table: "ProductUnits");

            migrationBuilder.DropIndex(
                name: "IX_ProductUnits_UnitId",
                table: "ProductUnits");

            migrationBuilder.DropColumn(
                name: "ProductUnitId",
                table: "SalesOrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductUnitId1",
                table: "SalesOrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductUnitId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductUnitId1",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "Factor",
                table: "ProductUnits");

            migrationBuilder.RenameTable(
                name: "ProductUnits",
                newName: "ProductUnit");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "ProductUnit",
                newName: "QuantityPerUnit");

            migrationBuilder.RenameColumn(
                name: "SalePrice",
                table: "ProductUnit",
                newName: "UnitPrice");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUnits_ProductId",
                table: "ProductUnit",
                newName: "IX_ProductUnit_ProductId");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUnit",
                table: "ProductUnit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnit_Products_ProductId",
                table: "ProductUnit",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_Products_ProductId",
                table: "PurchaseOrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Suppliers_SupplierId",
                table: "PurchaseOrders",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetails_Products_ProductId",
                table: "SalesOrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetails_SalesOrders_SalesOrderId",
                table: "SalesOrderDetails",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Customers_CustomerId",
                table: "SalesOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
