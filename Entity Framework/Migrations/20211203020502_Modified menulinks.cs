using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework.Migrations
{
    public partial class Modifiedmenulinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "MenuLinks",
                keyColumn: "Name",
                keyValue: "AJAX",
                column: "LinkURL",
                value: "/AJAX/");

            migrationBuilder.UpdateData(
                table: "MenuLinks",
                keyColumn: "Name",
                keyValue: "Cities",
                columns: new[] { "LinkURL", "Title" },
                values: new object[] { "/Cities/", "Cities" });

            migrationBuilder.UpdateData(
                table: "MenuLinks",
                keyColumn: "Name",
                keyValue: "Countries",
                columns: new[] { "LinkURL", "Title" },
                values: new object[] { "/Countries/", "Countries" });

            migrationBuilder.InsertData(
                table: "MenuLinks",
                columns: new[] { "Name", "LinkURL", "Title" },
                values: new object[] { "People", "/Home/", "People" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuLinks",
                keyColumn: "Name",
                keyValue: "People");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "MenuLinks",
                keyColumn: "Name",
                keyValue: "AJAX",
                column: "LinkURL",
                value: "/AJAX/Index");

            migrationBuilder.UpdateData(
                table: "MenuLinks",
                keyColumn: "Name",
                keyValue: "Cities",
                columns: new[] { "LinkURL", "Title" },
                values: new object[] { "/Cities/Index", "View cities" });

            migrationBuilder.UpdateData(
                table: "MenuLinks",
                keyColumn: "Name",
                keyValue: "Countries",
                columns: new[] { "LinkURL", "Title" },
                values: new object[] { "/Countries/Index", "View countries" });
        }
    }
}
