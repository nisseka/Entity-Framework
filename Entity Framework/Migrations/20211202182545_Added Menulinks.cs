using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework.Migrations
{
    public partial class AddedMenulinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuLinks",
                columns: new[] { "Name", "LinkURL", "Title" },
                values: new object[] { "Cities", "/Cities/Index", "View cities" });

            migrationBuilder.InsertData(
                table: "MenuLinks",
                columns: new[] { "Name", "LinkURL", "Title" },
                values: new object[] { "Countries", "/Countries/Index", "View countries" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuLinks",
                keyColumn: "Name",
                keyValue: "Cities");

            migrationBuilder.DeleteData(
                table: "MenuLinks",
                keyColumn: "Name",
                keyValue: "Countries");
        }
    }
}
