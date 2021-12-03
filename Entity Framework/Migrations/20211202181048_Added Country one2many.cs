using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework.Migrations
{
    public partial class AddedCountryone2many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cities",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Cities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    CountryCode = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "Name" },
                values: new object[] { 1, "SE", "Sverige" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Lidköping" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 2, 1, "Skövde" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 3, 1, "Skara" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 1,
                column: "CityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 2,
                column: "CityId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 3,
                column: "CityId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityId");

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Name" },
                values: new object[,]
                {
                    { 1, "Lidköping" },
                    { 2, "Skövde" },
                    { 3, "Skara" }
                });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 1,
                column: "CityId",
                value: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
