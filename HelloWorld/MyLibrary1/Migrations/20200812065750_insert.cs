using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrary1.Migrations
{
    public partial class insert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "cell Phone" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "CreatedDate", "Name", "Price" },
                values: new object[] { 1, 1, new DateTime(2020, 8, 12, 13, 57, 50, 512, DateTimeKind.Local).AddTicks(9744), "iphone6", 455641m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "CreatedDate", "Name", "Price" },
                values: new object[] { 2, 1, new DateTime(2020, 8, 12, 13, 57, 50, 514, DateTimeKind.Local).AddTicks(9671), "iphone7", 5445454m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
