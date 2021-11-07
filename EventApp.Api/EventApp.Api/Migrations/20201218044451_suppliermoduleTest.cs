using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventApp.Api.Migrations
{
    public partial class suppliermoduleTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 8, nullable: true),
                    Tocreation = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 65535, nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Contact1 = table.Column<string>(maxLength: 10, nullable: false),
                    Contact2 = table.Column<string>(nullable: true),
                    Nic = table.Column<string>(maxLength: 12, nullable: true),
                    Passport = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 65535, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    SupplierType = table.Column<int>(nullable: false),
                    SupplierStatus = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CreatorId",
                table: "Suppliers",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
