using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrary1.Migrations
{
    public partial class addsomereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "id", "name" },
                values: new object[] { 2, "MotoBike" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 14, 18, 0, 141, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 14, 18, 0, 143, DateTimeKind.Local).AddTicks(8906));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "CreatedDate", "Name", "Price" },
                values: new object[] { 3, 2, new DateTime(2020, 8, 12, 14, 18, 0, 144, DateTimeKind.Local).AddTicks(526), "wave 110cc", 3636363m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "CreatedDate", "Name", "Price" },
                values: new object[] { 4, 2, new DateTime(2020, 8, 12, 14, 18, 0, 144, DateTimeKind.Local).AddTicks(555), "jupiter 150cc", 898898m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 13, 57, 50, 512, DateTimeKind.Local).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 13, 57, 50, 514, DateTimeKind.Local).AddTicks(9671));
        }
    }
}
