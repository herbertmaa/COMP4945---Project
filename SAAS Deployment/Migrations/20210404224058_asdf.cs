using Microsoft.EntityFrameworkCore.Migrations;

namespace SAAS_Deployment.Migrations
{
    public partial class asdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
