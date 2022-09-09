using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCWebApp.Migrations
{
    public partial class AbelEF2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryName);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: false),
                    CountryForeignKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryForeignKey",
                        column: x => x.CountryForeignKey,
                        principalTable: "Countries",
                        principalColumn: "CountryName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CityForeignKey = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                    table.ForeignKey(
                        name: "FK_People_Cities_CityForeignKey",
                        column: x => x.CityForeignKey,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                column: "CountryName",
                value: "Sverige");

            migrationBuilder.InsertData(
                table: "Countries",
                column: "CountryName",
                value: "Norge");

            migrationBuilder.InsertData(
                table: "Countries",
                column: "CountryName",
                value: "Danmark");

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CityName", "CountryForeignKey" },
                values: new object[] { 1, "Stockholm", "Sverige" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CityName", "CountryForeignKey" },
                values: new object[] { 2, "Oslo", "Norge" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CityName", "CountryForeignKey" },
                values: new object[] { 3, "Köpenhamn", "Danmark" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "CityForeignKey", "Name", "PhoneNumber" },
                values: new object[] { 1, 1, "Jens Jensson", "123456789" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "CityForeignKey", "Name", "PhoneNumber" },
                values: new object[] { 2, 2, "Anna Andersson", "987654321" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "CityForeignKey", "Name", "PhoneNumber" },
                values: new object[] { 3, 3, "Sven Svensson", "123123123" });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryForeignKey",
                table: "Cities",
                column: "CountryForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_People_CityForeignKey",
                table: "People",
                column: "CityForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
