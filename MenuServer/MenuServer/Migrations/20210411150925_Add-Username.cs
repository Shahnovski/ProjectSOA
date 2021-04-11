using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuServer.Migrations
{
    public partial class AddUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Menu_DayOfWeekId_TimeOfDayId",
                table: "Menu");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Menu",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Menu_DayOfWeekId_TimeOfDayId_Username",
                table: "Menu",
                columns: new[] { "DayOfWeekId", "TimeOfDayId", "Username" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Menu_DayOfWeekId_TimeOfDayId_Username",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Menu");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Menu_DayOfWeekId_TimeOfDayId",
                table: "Menu",
                columns: new[] { "DayOfWeekId", "TimeOfDayId" });
        }
    }
}
