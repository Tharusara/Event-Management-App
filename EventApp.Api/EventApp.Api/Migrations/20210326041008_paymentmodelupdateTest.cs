using Microsoft.EntityFrameworkCore.Migrations;

namespace EventApp.Api.Migrations
{
    public partial class paymentmodelupdateTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ChequeNo",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ChequeBranch",
                table: "Payments",
                maxLength: 65535,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 65535);

            migrationBuilder.AlterColumn<string>(
                name: "ChequeBank",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "ChequeNo",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChequeBranch",
                table: "Payments",
                type: "nvarchar(max)",
                maxLength: 65535,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 65535,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChequeBank",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
