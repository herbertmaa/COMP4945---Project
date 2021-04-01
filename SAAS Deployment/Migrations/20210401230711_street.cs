using Microsoft.EntityFrameworkCore.Migrations;

namespace SAAS_Deployment.Migrations
{
    public partial class street : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_FullAddress_fullAddressStreet",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_fullAddressStreet",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "fullAddressStreet",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employee",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "fullAddressStreet",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fullAddressStreet",
                table: "Employee",
                column: "fullAddressStreet");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_FullAddress_fullAddressStreet",
                table: "Employee",
                column: "fullAddressStreet",
                principalTable: "FullAddress",
                principalColumn: "Street",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
