using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixGlobalFilters2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 56, 40, 952, DateTimeKind.Utc).AddTicks(3355));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 56, 40, 952, DateTimeKind.Utc).AddTicks(3356));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 56, 40, 952, DateTimeKind.Utc).AddTicks(3357));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 56, 40, 952, DateTimeKind.Utc).AddTicks(3358));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 6, 56, 40, 952, DateTimeKind.Utc).AddTicks(3359));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 56, 40, 952, DateTimeKind.Utc).AddTicks(3245), new DateTime(2025, 9, 16, 6, 56, 40, 952, DateTimeKind.Utc).AddTicks(3246) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 56, 40, 952, DateTimeKind.Utc).AddTicks(3249), new DateTime(2025, 9, 16, 6, 56, 40, 952, DateTimeKind.Utc).AddTicks(3249) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 56, 40, 952, DateTimeKind.Utc).AddTicks(3251), new DateTime(2025, 9, 16, 6, 56, 40, 952, DateTimeKind.Utc).AddTicks(3251) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
