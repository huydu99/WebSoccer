using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSoccer.DataAccess.Migrations
{
    public partial class UpdateAll123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionPrice",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 12, 17, 10, 8, 25, 867, DateTimeKind.Local).AddTicks(7846));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 12, 17, 10, 8, 25, 867, DateTimeKind.Local).AddTicks(7951));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PromotionPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 12, 17, 9, 11, 17, 2, DateTimeKind.Local).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "PromotionPrice" },
                values: new object[] { new DateTime(2023, 12, 17, 9, 11, 17, 2, DateTimeKind.Local).AddTicks(440), 25000.0 });
        }
    }
}
