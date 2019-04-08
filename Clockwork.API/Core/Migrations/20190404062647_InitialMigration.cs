using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Clockwork.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentTimeQueries",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientIp = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    UTCTime = table.Column<DateTime>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    DisplayId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTimeQueries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceLoggings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    WorkStation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLoggings", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentTimeQueries");

            migrationBuilder.DropTable(
                name: "ServiceLoggings");
        }
    }
}
