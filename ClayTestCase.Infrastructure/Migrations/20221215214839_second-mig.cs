using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClayTestCase.Infrastructure.Migrations
{
    public partial class secondmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessRoles_Doors_DoorId",
                table: "AccessRoles");

            migrationBuilder.DropIndex(
                name: "IX_AccessRoles_DoorId",
                table: "AccessRoles");

            migrationBuilder.DropColumn(
                name: "DoorId",
                table: "AccessRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoorId",
                table: "AccessRoles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccessRoles_DoorId",
                table: "AccessRoles",
                column: "DoorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessRoles_Doors_DoorId",
                table: "AccessRoles",
                column: "DoorId",
                principalTable: "Doors",
                principalColumn: "Id");
        }
    }
}
