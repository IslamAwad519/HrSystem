using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrSystem.DataAccess.Migrations
{
    public partial class IntialCreateDBBB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "Dno",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MgrId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Dno",
                table: "Employees",
                column: "Dno");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MgrId",
                table: "Departments",
                column: "MgrId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_MgrId",
                table: "Departments",
                column: "MgrId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_Dno",
                table: "Employees",
                column: "Dno",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_MgrId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_Dno",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Dno",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_MgrId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Dno",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MgrId",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
