using Microsoft.EntityFrameworkCore.Migrations;

namespace EventApp.Api.Migrations
{
    public partial class updatingmodelsforcreationmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_AspNetUsers_CreatorId",
                table: "Suppliers");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Suppliers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatorId",
                table: "Employees",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreatorId",
                table: "Customers",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_CreatorId",
                table: "Customers",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_CreatorId",
                table: "Employees",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_AspNetUsers_CreatorId",
                table: "Suppliers",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_CreatorId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_CreatorId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_AspNetUsers_CreatorId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CreatorId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CreatorId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Suppliers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_AspNetUsers_CreatorId",
                table: "Suppliers",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
