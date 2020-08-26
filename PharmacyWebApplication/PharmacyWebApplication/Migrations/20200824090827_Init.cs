using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyWebApplication.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "district",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    _name = table.Column<string>(maxLength: 100, nullable: true),
                    _prefix = table.Column<string>(maxLength: 20, nullable: true),
                    _province_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "province",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    _name = table.Column<string>(maxLength: 50, nullable: true),
                    _code = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNum = table.Column<string>(nullable: true),
                    Avatar_Path = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ward",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    _name = table.Column<string>(maxLength: 50, nullable: false),
                    _prefix = table.Column<string>(maxLength: 20, nullable: true),
                    _province_id = table.Column<int>(nullable: true),
                    _district_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Address_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Province = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Ward = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    User_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Address_Id);
                    table.ForeignKey(
                        name: "FK_Address_User_User_Id",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_User_Id",
                table: "Address",
                column: "User_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "district");

            migrationBuilder.DropTable(
                name: "province");

            migrationBuilder.DropTable(
                name: "ward");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
