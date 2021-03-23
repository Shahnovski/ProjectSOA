using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuServer.Migrations
{
    public partial class Initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_DayOfWeek_DayOfWeekId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_TimeOfDay_TimeOfDayId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "Menu");

            migrationBuilder.AlterColumn<int>(
                name: "TimeOfDayId",
                table: "Menu",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DayOfWeekId",
                table: "Menu",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_DayOfWeek_DayOfWeekId",
                table: "Menu",
                column: "DayOfWeekId",
                principalTable: "DayOfWeek",
                principalColumn: "DayOfWeekId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_TimeOfDay_TimeOfDayId",
                table: "Menu",
                column: "TimeOfDayId",
                principalTable: "TimeOfDay",
                principalColumn: "TimeOfDayId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_DayOfWeek_DayOfWeekId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_TimeOfDay_TimeOfDayId",
                table: "Menu");

            migrationBuilder.AlterColumn<int>(
                name: "TimeOfDayId",
                table: "Menu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DayOfWeekId",
                table: "Menu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeId",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_DayOfWeek_DayOfWeekId",
                table: "Menu",
                column: "DayOfWeekId",
                principalTable: "DayOfWeek",
                principalColumn: "DayOfWeekId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_TimeOfDay_TimeOfDayId",
                table: "Menu",
                column: "TimeOfDayId",
                principalTable: "TimeOfDay",
                principalColumn: "TimeOfDayId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
