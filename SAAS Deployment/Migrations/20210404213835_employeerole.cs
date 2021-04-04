using Microsoft.EntityFrameworkCore.Migrations;

namespace SAAS_Deployment.Migrations
{
    public partial class employeerole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "AspNetRoles",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
