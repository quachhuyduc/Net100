using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuachHuyDucBTH2.Migrations
{
    public partial class Create_Table_Student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentAddress",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentEmail",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentPhone",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentAddress",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentEmail",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentPhone",
                table: "Students");
        }
    }
}
