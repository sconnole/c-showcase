using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace c_showcase.Migrations
{
    /// <inheritdoc />
    public partial class AddGameDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Resources = table.Column<long>(type: "INTEGER", nullable: false),
                    ResourcesPerClick = table.Column<int>(type: "INTEGER", nullable: false),
                    ResourcesPerSecond = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameData");
        }
    }
}
