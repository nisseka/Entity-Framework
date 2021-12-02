using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework.Migrations
{
    public partial class AddedMenulinkstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuLinks",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    LinkURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuLinks", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "MenuLinks",
                columns: new[] { "Name", "LinkURL", "Title" },
                values: new object[] { "AJAX", "/AJAX/Index", "AJAX Mode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuLinks");
        }
    }
}
