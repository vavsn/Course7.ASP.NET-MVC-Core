using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoureProject.DAL.SQLiteServer.Migrations
{
    public partial class Add_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Consolidated_Weathers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Consolidated_Weathers");
        }
    }
}
