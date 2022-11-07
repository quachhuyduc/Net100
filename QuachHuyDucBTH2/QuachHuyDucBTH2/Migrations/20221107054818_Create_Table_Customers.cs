using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuachHuyDucBTH2.Migrations
{
    public partial class Create_Table_Customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Customers");
        }
    }
}
