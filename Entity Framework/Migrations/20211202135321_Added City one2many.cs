using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework.Migrations
{
    public partial class AddedCityone2many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Name" },
                values: new object[] { 1, "Lidköping" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Name" },
                values: new object[] { 2, "Skövde" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Name" },
                values: new object[] { 3, "Skara" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 2,
                column: "CityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 3,
                column: "CityId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 1,
                column: "City",
                value: "Lidköping");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 2,
                column: "City",
                value: "Skövde");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 3,
                column: "City",
                value: "Skara");
        }
    }
}
