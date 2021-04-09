﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SAAS_Deployment.Migrations.ApplicationDb
{
    public partial class jsonstring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "Client",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "Client");
        }
    }
}
