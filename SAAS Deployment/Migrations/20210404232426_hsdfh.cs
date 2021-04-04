using Microsoft.EntityFrameworkCore.Migrations;

namespace SAAS_Deployment.Migrations
{
    public partial class hsdfh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
