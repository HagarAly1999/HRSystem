using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp.Migrations
{
    public partial class empinital2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_Departmentid",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Departmentid",
                schema: "dbo",
                table: "Employee",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Departmentid",
                schema: "dbo",
                table: "Employee",
                newName: "IX_Employee_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                schema: "dbo",
                table: "Employee",
                column: "DepartmentId",
                principalSchema: "dbo",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                schema: "dbo",
                table: "Employee",
                newName: "Departmentid");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DepartmentId",
                schema: "dbo",
                table: "Employee",
                newName: "IX_Employee_Departmentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_Departmentid",
                schema: "dbo",
                table: "Employee",
                column: "Departmentid",
                principalSchema: "dbo",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
