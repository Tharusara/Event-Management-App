using Microsoft.EntityFrameworkCore.Migrations;

namespace EventApp.Api.Migrations
{
    public partial class PhotoMappingForemployeeAndItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_EmployeeId",
                table: "Photos",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ItemId",
                table: "Photos",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Employees_EmployeeId",
                table: "Photos",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Items_ItemId",
                table: "Photos",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Employees_EmployeeId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Items_ItemId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_EmployeeId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_ItemId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Photos");
        }
    }
}
