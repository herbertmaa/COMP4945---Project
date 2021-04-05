using Microsoft.EntityFrameworkCore.Migrations;

namespace SAAS_Deployment.Migrations
{
    public partial class wefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_FullAddress_FullAddressId",
                table: "Person");

            migrationBuilder.AlterColumn<int>(
                name: "FullAddressId",
                table: "Person",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Person",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_FullAddress_FullAddressId",
                table: "Person",
                column: "FullAddressId",
                principalTable: "FullAddress",
                principalColumn: "FullAddressId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_FullAddress_FullAddressId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Person");

            migrationBuilder.AlterColumn<int>(
                name: "FullAddressId",
                table: "Person",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_FullAddress_FullAddressId",
                table: "Person",
                column: "FullAddressId",
                principalTable: "FullAddress",
                principalColumn: "FullAddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
