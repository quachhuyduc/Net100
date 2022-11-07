using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuachHuyDucBTH2.Migrations
{
    public partial class Create_Table_Employees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeAddress",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeEmail",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeePhone",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeAddress",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeEmail",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeePhone",
                table: "Employees");
        }
    }
}
