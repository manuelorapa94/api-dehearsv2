using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ehearsApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReasonTypes",
                columns: table => new
                {
                    reasonTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reasonTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonTypes", x => x.reasonTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReasonTypes");
        }
    }
}
