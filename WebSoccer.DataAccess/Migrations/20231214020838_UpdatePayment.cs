using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSoccer.DataAccess.Migrations
{
    public partial class UpdatePayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymemtMethod",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 12, 14, 9, 8, 37, 988, DateTimeKind.Local).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 12, 14, 9, 8, 37, 988, DateTimeKind.Local).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 12, 14, 9, 8, 37, 988, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 12, 14, 9, 8, 37, 988, DateTimeKind.Local).AddTicks(1386));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymemtMethod",
                table: "OrderHeaders");

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
    }
}
