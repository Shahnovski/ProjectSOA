using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuServer.Migrations
{
    public partial class Initial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Menu_DayOfWeekId",
                table: "Menu");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Menu_DayOfWeekId_TimeOfDayId",
                table: "Menu",
                columns: new[] { "DayOfWeekId", "TimeOfDayId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Menu_DayOfWeekId_TimeOfDayId",
                table: "Menu");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_DayOfWeekId",
                table: "Menu",
                column: "DayOfWeekId");
        }
    }
}
