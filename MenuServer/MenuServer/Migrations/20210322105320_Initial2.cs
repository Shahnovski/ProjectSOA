using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuServer.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOfWeek_Menu_MenuId",
                table: "DayOfWeek");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Menu_MenuId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeOfDay_Menu_MenuId",
                table: "TimeOfDay");

            migrationBuilder.DropIndex(
                name: "IX_TimeOfDay_MenuId",
                table: "TimeOfDay");

            migrationBuilder.DropIndex(
                name: "IX_Dish_MenuId",
                table: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_DayOfWeek_MenuId",
                table: "DayOfWeek");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "TimeOfDay");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "DayOfWeek");

            migrationBuilder.AddColumn<int>(
                name: "DIshId",
                table: "Menu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "Menu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeekId",
                table: "Menu",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeId",
                table: "Menu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeOfDayId",
                table: "Menu",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_DIshId",
                table: "Menu",
                column: "DIshId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_DayOfWeekId",
                table: "Menu",
                column: "DayOfWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_TimeOfDayId",
                table: "Menu",
                column: "TimeOfDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Dish_DIshId",
                table: "Menu",
                column: "DIshId",
                principalTable: "Dish",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Dish_DIshId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_DayOfWeek_DayOfWeekId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_TimeOfDay_TimeOfDayId",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_DIshId",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_DayOfWeekId",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_TimeOfDayId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "DIshId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "DayOfWeekId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "TimeOfDayId",
                table: "Menu");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "TimeOfDay",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Dish",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "DayOfWeek",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeOfDay_MenuId",
                table: "TimeOfDay",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_MenuId",
                table: "Dish",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfWeek_MenuId",
                table: "DayOfWeek",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfWeek_Menu_MenuId",
                table: "DayOfWeek",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Menu_MenuId",
                table: "Dish",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOfDay_Menu_MenuId",
                table: "TimeOfDay",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
