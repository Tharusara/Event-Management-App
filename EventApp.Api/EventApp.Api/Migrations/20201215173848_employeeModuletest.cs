using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventApp.Api.Migrations
{
    public partial class employeeModuletest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 8, nullable: true),
                    CallingName = table.Column<string>(maxLength: 255, nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: true),
                    DOBirth = table.Column<DateTime>(nullable: false),
                    Nic = table.Column<string>(maxLength: 12, nullable: false),
                    Address = table.Column<string>(maxLength: 65535, nullable: true),
                    Mobile = table.Column<string>(maxLength: 10, nullable: true),
                    Land = table.Column<string>(maxLength: 10, nullable: true),
                    Description = table.Column<string>(maxLength: 65535, nullable: true),
                    Dorecruite = table.Column<DateTime>(nullable: false),
                    PhotoUrl = table.Column<string>(nullable: true),
                    ToCreation = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    CivilStatus = table.Column<int>(nullable: false),
                    Designation = table.Column<int>(nullable: false),
                    EmployeeStatus = table.Column<int>(nullable: false),
                    NameTitle = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
