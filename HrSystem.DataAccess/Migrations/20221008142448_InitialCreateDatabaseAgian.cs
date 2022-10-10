using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrSystem.DataAccess.Migrations
{
    public partial class InitialCreateDatabaseAgian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePhoneNumber_Employees_PhoneNumberId",
                table: "EmployeePhoneNumber");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_MangrId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_MangrId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePhoneNumber_PhoneNumberId",
                table: "EmployeePhoneNumber");

            migrationBuilder.DropColumn(
                name: "MangrId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumberID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumberId",
                table: "EmployeePhoneNumber");

            migrationBuilder.DropColumn(
                name: "MangrId",
                table: "Departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MangrId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumberID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumberId",
                table: "EmployeePhoneNumber",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MangrId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MangrId",
                table: "Employees",
                column: "MangrId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneNumber_PhoneNumberId",
                table: "EmployeePhoneNumber",
                column: "PhoneNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePhoneNumber_Employees_PhoneNumberId",
                table: "EmployeePhoneNumber",
                column: "PhoneNumberId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_MangrId",
                table: "Employees",
                column: "MangrId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
