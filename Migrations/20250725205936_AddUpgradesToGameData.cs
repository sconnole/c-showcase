using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace c_showcase.Migrations
{
    /// <inheritdoc />
    public partial class AddUpgradesToGameData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Upgrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    BaseCost = table.Column<int>(type: "INTEGER", nullable: false),
                    ResourcesPerSecond = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upgrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameDataUpgrades",
                columns: table => new
                {
                    GameDataId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpgradeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDataUpgrades", x => new { x.GameDataId, x.UpgradeId });
                    table.ForeignKey(
                        name: "FK_GameDataUpgrades_GameData_GameDataId",
                        column: x => x.GameDataId,
                        principalTable: "GameData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDataUpgrades_Upgrades_UpgradeId",
                        column: x => x.UpgradeId,
                        principalTable: "Upgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Upgrades",
                columns: new[] { "Id", "BaseCost", "Description", "Name", "ResourcesPerSecond" },
                values: new object[,]
                {
                    { 1, 100, "+1 Orb/sec", "Auto Clicker", 0 },
                    { 2, 400, "+2 Orb/sec", "Small Harvester", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameDataUpgrades_UpgradeId",
                table: "GameDataUpgrades",
                column: "UpgradeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDataUpgrades");

            migrationBuilder.DropTable(
                name: "Upgrades");
        }
    }
}
