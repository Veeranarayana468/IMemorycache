using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryStock.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockCount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastRestocked = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "LastRestocked", "Name", "Price", "StockCount" },
                values: new object[,]
                {
                    { 1, "Electronics", new DateTime(2026, 1, 30, 18, 49, 5, 212, DateTimeKind.Local).AddTicks(8466), "Laptop", 1200m, 5 },
                    { 2, "Electronics", new DateTime(2026, 2, 7, 18, 49, 5, 212, DateTimeKind.Local).AddTicks(8481), "Mouse", 25m, 50 },
                    { 3, "Electronics", new DateTime(2026, 1, 25, 18, 49, 5, 212, DateTimeKind.Local).AddTicks(8486), "Monitor", 300m, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
