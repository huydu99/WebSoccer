using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSoccer.DataAccess.Migrations
{
    public partial class Update2a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 12, 13, 22, 31, 9, 899, DateTimeKind.Local).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 12, 13, 22, 31, 9, 899, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 12, 13, 22, 31, 9, 899, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 12, 13, 22, 31, 9, 899, DateTimeKind.Local).AddTicks(9356));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 12, 13, 17, 13, 42, 335, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 12, 13, 17, 13, 42, 335, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 12, 13, 17, 13, 42, 335, DateTimeKind.Local).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 12, 13, 17, 13, 42, 335, DateTimeKind.Local).AddTicks(5849));
        }
    }
}
