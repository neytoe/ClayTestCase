using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClayTestCase.Infrastructure.Migrations
{
    public partial class fifthmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Doors");

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DoorId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeEmail = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeRole = table.Column<string>(type: "TEXT", nullable: false),
                    IsAccessGranted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Doors",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
