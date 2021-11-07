using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventApp.Api.Migrations
{
    public partial class othermodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSuppliers_Items_ItemId",
                table: "ItemSuppliers");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 8, nullable: true),
                    Tocreation = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 65535, nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    GuestCount = table.Column<int>(nullable: false),
                    VipDetails = table.Column<string>(nullable: true),
                    FunctionboardDetails = table.Column<string>(nullable: true),
                    GuestswithSpecialneeds = table.Column<string>(nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    Fee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    HallFee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EventStatus = table.Column<int>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    ArrangementStyle = table.Column<int>(nullable: false),
                    ChairCoverColor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 8, nullable: true),
                    Tocreation = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 65535, nullable: true),
                    Name = table.Column<string>(nullable: false),
                    HallStatus = table.Column<int>(nullable: false),
                    HallType = table.Column<int>(nullable: false),
                    Hourfee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Squarefeet = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    CreatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Halls_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 8, nullable: true),
                    Tocreation = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 65535, nullable: true),
                    Hours = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Extrahourcost = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PackageStatus = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 8, nullable: true),
                    Tocreation = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 65535, nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    UnitCharge = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ServiceStatus = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatorId",
                table: "Events",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CustomerId",
                table: "Events",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_CreatorId",
                table: "Halls",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CreatorId",
                table: "Packages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CreatorId",
                table: "Services",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSuppliers_Items_ItemId",
                table: "ItemSuppliers",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSuppliers_Items_ItemId",
                table: "ItemSuppliers");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSuppliers_Items_ItemId",
                table: "ItemSuppliers",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
