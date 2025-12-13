using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updatedentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Suppliers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Suppliers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ToltalAmount",
                table: "PurchaseOrders",
                newName: "TotalAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Suppliers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Suppliers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "PurchaseOrders",
                newName: "ToltalAmount");
        }
    }
}
