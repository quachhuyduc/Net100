using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuachHuyDucBTH2.Migrations
{
    public partial class Create_Table_Persons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonAddress",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonEmail",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonPhone",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonAddress",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonEmail",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonPhone",
                table: "Persons");
        }
    }
}
