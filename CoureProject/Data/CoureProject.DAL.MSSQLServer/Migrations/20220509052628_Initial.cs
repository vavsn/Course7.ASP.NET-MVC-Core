using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoureProject.DAL.SQLiteServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeatherID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    location_type = table.Column<string>(type: "TEXT", nullable: false),
                    latt_long = table.Column<string>(type: "TEXT", nullable: false),
                    woeid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    slug = table.Column<string>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: false),
                    crawl_rate = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    weather_state_name = table.Column<string>(type: "TEXT", nullable: false),
                    weather_state_abbr = table.Column<string>(type: "TEXT", nullable: false),
                    wind_direction_compass = table.Column<string>(type: "TEXT", nullable: false),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    applicable_date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    min_temp = table.Column<double>(type: "REAL", nullable: false),
                    max_temp = table.Column<double>(type: "REAL", nullable: false),
                    the_temp = table.Column<double>(type: "REAL", nullable: false),
                    wind_speed = table.Column<double>(type: "REAL", nullable: false),
                    wind_direction = table.Column<double>(type: "REAL", nullable: false),
                    air_pressure = table.Column<double>(type: "REAL", nullable: false),
                    humidity = table.Column<double>(type: "REAL", nullable: false),
                    visibility = table.Column<double>(type: "REAL", nullable: false),
                    predictability = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
