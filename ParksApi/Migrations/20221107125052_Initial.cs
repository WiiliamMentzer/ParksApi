using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksClient.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StateTitle = table.Column<string>(type: "varchar(25) CHARACTER SET utf8mb4", maxLength: 25, nullable: false),
                    StatePopulation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    ParkName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    ParkNational = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                    table.ForeignKey(
                        name: "FK_Parks_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "StatePopulation", "StateTitle" },
                values: new object[,]
                {
                    { 1, 1, "California" },
                    { 2, 2, "Texas" },
                    { 3, 3, "Washington" },
                    { 4, 4, "Oregon" },
                    { 5, 5, "Nevada" }
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "ParkName", "ParkNational", "StateId" },
                values: new object[,]
                {
                    { 1, "Yosemite", true, 1 },
                    { 2, "Joshua Tree", true, 1 },
                    { 5, "Big Spring State", false, 2 },
                    { 3, "Olympic National", true, 3 },
                    { 4, "Cedar Lake", true, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parks_StateId",
                table: "Parks",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
