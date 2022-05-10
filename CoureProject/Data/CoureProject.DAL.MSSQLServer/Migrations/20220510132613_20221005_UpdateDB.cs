using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoureProject.DAL.SQLiteServer.Migrations
{
    public partial class _20221005_UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "created",
                table: "Weathers",
                newName: "create");

            migrationBuilder.AlterColumn<int>(
                name: "predictability",
                table: "Weathers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "humidity",
                table: "Weathers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "create",
                table: "Weathers",
                newName: "created");

            migrationBuilder.AlterColumn<double>(
                name: "predictability",
                table: "Weathers",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "humidity",
                table: "Weathers",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
