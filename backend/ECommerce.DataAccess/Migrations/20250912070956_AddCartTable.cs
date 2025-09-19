using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(9139), "Elektronik", null },
                    { 2, new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(9141), "Moda", null },
                    { 3, new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(9142), "Ev & Yaşam", null },
                    { 4, new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(9144), "Kitap", null },
                    { 5, new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(9145), "Spor", null }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(8944), new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(8945) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(8949), new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(8950) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(8953), new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(8953) });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId_ProductId",
                table: "Cart",
                columns: new[] { "UserId", "ProductId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 11, 10, 12, 26, 845, DateTimeKind.Utc).AddTicks(5783), new DateTime(2025, 9, 11, 10, 12, 26, 845, DateTimeKind.Utc).AddTicks(5785) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 11, 10, 12, 26, 845, DateTimeKind.Utc).AddTicks(5792), new DateTime(2025, 9, 11, 10, 12, 26, 845, DateTimeKind.Utc).AddTicks(5793) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 11, 10, 12, 26, 845, DateTimeKind.Utc).AddTicks(5796), new DateTime(2025, 9, 11, 10, 12, 26, 845, DateTimeKind.Utc).AddTicks(5797) });
        }
    }
}
