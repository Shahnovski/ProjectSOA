using Microsoft.EntityFrameworkCore.Migrations;

namespace BankServer.Migrations
{
    public partial class AddUserNameForAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountUserName",
                table: "Account",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountUserName",
                table: "Account");
        }
    }
}
