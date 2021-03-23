using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuServer.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Dish_DIshId",
                table: "Menu");

            migrationBuilder.RenameColumn(
                name: "DIshId",
                table: "Menu",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_DIshId",
                table: "Menu",
                newName: "IX_Menu_DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Dish_DishId",
                table: "Menu",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Dish_DishId",
                table: "Menu");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "Menu",
                newName: "DIshId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_DishId",
                table: "Menu",
                newName: "IX_Menu_DIshId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Dish_DIshId",
                table: "Menu",
                column: "DIshId",
                principalTable: "Dish",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
