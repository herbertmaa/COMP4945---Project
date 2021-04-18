using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAAS_Deployment.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobby",
                columns: table => new
                {
                    HobbyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobby", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Person_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    DateJoined = table.Column<DateTime>(nullable: true),
                    EmerContact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Person_Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeHobby",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    HobbyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHobby", x => new { x.EmployeeId, x.HobbyId });
                    table.ForeignKey(
                        name: "FK_EmployeeHobby_Person_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Person",
                        principalColumn: "Person_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeHobby_Hobby_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobby",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FullAddress",
                columns: table => new
                {
                    FullAddress_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(maxLength: 7, nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Person_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullAddress", x => x.FullAddress_Id);
                    table.ForeignKey(
                        name: "FK_FullAddress_Person_Person_Id",
                        column: x => x.Person_Id,
                        principalTable: "Person",
                        principalColumn: "Person_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHobby_HobbyId",
                table: "EmployeeHobby",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_FullAddress_Person_Id",
                table: "FullAddress",
                column: "Person_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeHobby");

            migrationBuilder.DropTable(
                name: "FullAddress");

            migrationBuilder.DropTable(
                name: "Hobby");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
