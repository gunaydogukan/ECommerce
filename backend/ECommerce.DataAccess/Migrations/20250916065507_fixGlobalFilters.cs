using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixGlobalFilters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 55, 7, 135, DateTimeKind.Utc).AddTicks(1331));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 55, 7, 135, DateTimeKind.Utc).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 55, 7, 135, DateTimeKind.Utc).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 55, 7, 135, DateTimeKind.Utc).AddTicks(1335));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 55, 7, 135, DateTimeKind.Utc).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 55, 7, 135, DateTimeKind.Utc).AddTicks(1186), new DateTime(2025, 9, 16, 6, 55, 7, 135, DateTimeKind.Utc).AddTicks(1187) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 55, 7, 135, DateTimeKind.Utc).AddTicks(1191), new DateTime(2025, 9, 16, 6, 55, 7, 135, DateTimeKind.Utc).AddTicks(1192) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 55, 7, 135, DateTimeKind.Utc).AddTicks(1193), new DateTime(2025, 9, 16, 6, 55, 7, 135, DateTimeKind.Utc).AddTicks(1194) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9937));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9940));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9942));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9944));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9684), new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9685) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9693), new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9694) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9697), new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9698) });
        }
    }
}
