using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoureProject.DAL.SQLiteServer.Migrations
{
    public partial class UpdateDB_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weathers",
                table: "Weathers");

            migrationBuilder.RenameTable(
                name: "Weathers",
                newName: "Weather");

            migrationBuilder.RenameTable(
                name: "Sources",
                newName: "Source");

            migrationBuilder.RenameTable(
                name: "Parents",
                newName: "Parent");

            migrationBuilder.AddColumn<int>(
                name: "Consolidated_Weatherwoeid",
                table: "Weather",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Consolidated_Weatherwoeid",
                table: "Source",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "woeid",
                table: "Parent",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weather",
                table: "Weather",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Source",
                table: "Source",
                column: "title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parent",
                table: "Parent",
                column: "woeid");

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
                    timezone = table.Column<string>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Weather_Consolidated_Weatherwoeid",
                table: "Weather",
                column: "Consolidated_Weatherwoeid");

            migrationBuilder.CreateIndex(
                name: "IX_Source_Consolidated_Weatherwoeid",
                table: "Source",
                column: "Consolidated_Weatherwoeid");

            migrationBuilder.CreateIndex(
                name: "IX_Consolidated_Weathers_parentwoeid",
                table: "Consolidated_Weathers",
                column: "parentwoeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Source_Consolidated_Weathers_Consolidated_Weatherwoeid",
                table: "Source",
                column: "Consolidated_Weatherwoeid",
                principalTable: "Consolidated_Weathers",
                principalColumn: "woeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Weather_Consolidated_Weathers_Consolidated_Weatherwoeid",
                table: "Weather",
                column: "Consolidated_Weatherwoeid",
                principalTable: "Consolidated_Weathers",
                principalColumn: "woeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Source_Consolidated_Weathers_Consolidated_Weatherwoeid",
                table: "Source");

            migrationBuilder.DropForeignKey(
                name: "FK_Weather_Consolidated_Weathers_Consolidated_Weatherwoeid",
                table: "Weather");

            migrationBuilder.DropTable(
                name: "Consolidated_Weathers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weather",
                table: "Weather");

            migrationBuilder.DropIndex(
                name: "IX_Weather_Consolidated_Weatherwoeid",
                table: "Weather");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Source",
                table: "Source");

            migrationBuilder.DropIndex(
                name: "IX_Source_Consolidated_Weatherwoeid",
                table: "Source");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parent",
                table: "Parent");

            migrationBuilder.DropColumn(
                name: "Consolidated_Weatherwoeid",
                table: "Weather");

            migrationBuilder.DropColumn(
                name: "Consolidated_Weatherwoeid",
                table: "Source");

            migrationBuilder.RenameTable(
                name: "Weather",
                newName: "Weathers");

            migrationBuilder.RenameTable(
                name: "Source",
                newName: "Sources");

            migrationBuilder.RenameTable(
                name: "Parent",
                newName: "Parents");

            migrationBuilder.AlterColumn<int>(
                name: "woeid",
                table: "Parents",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weathers",
                table: "Weathers",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    WeatherID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });
        }
    }
}
