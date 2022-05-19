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
                name: "Parent",
                columns: table => new
                {
                    woeid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    location_type = table.Column<string>(type: "TEXT", nullable: false),
                    latt_long = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.woeid);
                });

            migrationBuilder.CreateTable(
                name: "Consolidated_Weathers",
                columns: table => new
                {
                    woeid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    sun_rise = table.Column<DateTime>(type: "TEXT", nullable: false),
                    sun_set = table.Column<DateTime>(type: "TEXT", nullable: false),
                    timezone_name = table.Column<string>(type: "TEXT", nullable: false),
                    parentwoeid = table.Column<int>(type: "INTEGER", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    location_type = table.Column<string>(type: "TEXT", nullable: false),
                    latt_long = table.Column<string>(type: "TEXT", nullable: false),
                    timezone = table.Column<string>(type: "TEXT", nullable: false),
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consolidated_Weathers", x => x.woeid);
                    table.ForeignKey(
                        name: "FK_Consolidated_Weathers_Parent_parentwoeid",
                        column: x => x.parentwoeid,
                        principalTable: "Parent",
                        principalColumn: "woeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    slug = table.Column<string>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: false),
                    crawl_rate = table.Column<int>(type: "INTEGER", nullable: false),
                    Consolidated_Weatherwoeid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.title);
                    table.ForeignKey(
                        name: "FK_Source_Consolidated_Weathers_Consolidated_Weatherwoeid",
                        column: x => x.Consolidated_Weatherwoeid,
                        principalTable: "Consolidated_Weathers",
                        principalColumn: "woeid");
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    weather_state_name = table.Column<string>(type: "TEXT", nullable: false),
                    weather_state_abbr = table.Column<string>(type: "TEXT", nullable: false),
                    wind_direction_compass = table.Column<string>(type: "TEXT", nullable: false),
                    create = table.Column<DateTime>(type: "TEXT", nullable: false),
                    applicable_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    min_temp = table.Column<float>(type: "REAL", nullable: false),
                    max_temp = table.Column<float>(type: "REAL", nullable: false),
                    the_temp = table.Column<float>(type: "REAL", nullable: false),
                    wind_speed = table.Column<float>(type: "REAL", nullable: false),
                    wind_direction = table.Column<float>(type: "REAL", nullable: false),
                    air_pressure = table.Column<float>(type: "REAL", nullable: false),
                    humidity = table.Column<int>(type: "INTEGER", nullable: false),
                    visibility = table.Column<float>(type: "REAL", nullable: false),
                    predictability = table.Column<int>(type: "INTEGER", nullable: false),
                    Consolidated_Weatherwoeid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.id);
                    table.ForeignKey(
                        name: "FK_Weather_Consolidated_Weathers_Consolidated_Weatherwoeid",
                        column: x => x.Consolidated_Weatherwoeid,
                        principalTable: "Consolidated_Weathers",
                        principalColumn: "woeid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consolidated_Weathers_parentwoeid",
                table: "Consolidated_Weathers",
                column: "parentwoeid");

            migrationBuilder.CreateIndex(
                name: "IX_Source_Consolidated_Weatherwoeid",
                table: "Source",
                column: "Consolidated_Weatherwoeid");

            migrationBuilder.CreateIndex(
                name: "IX_Weather_Consolidated_Weatherwoeid",
                table: "Weather",
                column: "Consolidated_Weatherwoeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Source");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Consolidated_Weathers");

            migrationBuilder.DropTable(
                name: "Parent");
        }
    }
}
