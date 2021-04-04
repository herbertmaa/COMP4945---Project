using Microsoft.EntityFrameworkCore.Migrations;

namespace SAAS_Deployment.Migrations
{
    public partial class oops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_Person_EmployeeId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_EmployeeId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RolesId",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_RolesId",
                table: "Person",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_AspNetRoles_RolesId",
                table: "Person",
                column: "RolesId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_AspNetRoles_RolesId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_RolesId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "AspNetRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_EmployeeId",
                table: "AspNetRoles",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_Person_EmployeeId",
                table: "AspNetRoles",
                column: "EmployeeId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
