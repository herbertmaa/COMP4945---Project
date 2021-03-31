using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAAS_Deployment.Data.Migrations
{
    public partial class AppDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FullAddress",
                columns: table => new
                {
                    Street = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullAddress", x => x.Street);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    fullAddressStreet = table.Column<string>(nullable: true),
                    DateJoined = table.Column<DateTime>(nullable: false),
                    EmerContact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_FullAddress_fullAddressStreet",
                        column: x => x.fullAddressStreet,
                        principalTable: "FullAddress",
                        principalColumn: "Street",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fullAddressStreet",
                table: "Employee",
                column: "fullAddressStreet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "FullAddress");
        }
    }
}
