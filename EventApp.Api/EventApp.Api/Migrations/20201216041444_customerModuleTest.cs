using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventApp.Api.Migrations
{
    public partial class customerModuleTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
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
                    CustomerType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
