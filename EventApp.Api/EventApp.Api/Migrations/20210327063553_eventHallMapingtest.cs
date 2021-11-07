using Microsoft.EntityFrameworkCore.Migrations;

namespace EventApp.Api.Migrations
{
    public partial class eventHallMapingtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_HallId",
                table: "Events",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Halls_HallId",
                table: "Events",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Halls_HallId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_HallId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "Events");
        }
    }
}
