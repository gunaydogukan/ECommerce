using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Roles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Permissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cart",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9937), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9940), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9942), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9944), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9946), false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9684), false, new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9685) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9693), false, new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9694) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9697), false, new DateTime(2025, 9, 16, 6, 47, 49, 739, DateTimeKind.Utc).AddTicks(9698) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cart");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 7, 9, 56, 110, DateTimeKind.Utc).AddTicks(9145));

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
        }
    }
}
