using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Continent = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Season = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Year = table.Column<short>(type: "INTEGER", nullable: false),
                    Opening = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Closing = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
