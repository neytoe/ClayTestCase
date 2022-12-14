using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClayTestCase.Infrastructure.Migrations
{
    public partial class secondmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doors_Office_OfficeId1",
                table: "Doors");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropIndex(
                name: "IX_Doors_OfficeId1",
                table: "Doors");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Doors");

            migrationBuilder.DropColumn(
                name: "OfficeId1",
                table: "Doors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Doors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId1",
                table: "Doors",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doors_OfficeId1",
                table: "Doors",
                column: "OfficeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Doors_Office_OfficeId1",
                table: "Doors",
                column: "OfficeId1",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
