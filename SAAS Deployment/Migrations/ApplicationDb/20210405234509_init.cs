using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAAS_Deployment.Migrations.ApplicationDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FullAddress",
                columns: table => new
                {
                    FullAddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullAddress", x => x.FullAddressId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    FullAddressId = table.Column<int>(nullable: true),
                    DateJoined = table.Column<DateTime>(nullable: true),
                    EmerContact = table.Column<string>(nullable: true),
                    RolesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_IdentityRole_RolesId",
                        column: x => x.RolesId,
                        principalTable: "IdentityRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_FullAddress_FullAddressId",
                        column: x => x.FullAddressId,
                        principalTable: "FullAddress",
                        principalColumn: "FullAddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_RolesId",
                table: "Person",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_FullAddressId",
                table: "Person",
                column: "FullAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "FullAddress");
        }
    }
}
