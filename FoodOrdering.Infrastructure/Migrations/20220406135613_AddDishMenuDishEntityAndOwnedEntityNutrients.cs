using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrdering.Infrastructure.Migrations
{
    public partial class AddDishMenuDishEntityAndOwnedEntityNutrients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishesMenus_DishesMenuId",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "DishesMenus");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_DishesMenuId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DishesMenuId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "Proteins",
                table: "Dishes",
                newName: "Nutrients_Proteins");

            migrationBuilder.RenameColumn(
                name: "Fats",
                table: "Dishes",
                newName: "Nutrients_Fats");

            migrationBuilder.RenameColumn(
                name: "Carbohydrates",
                table: "Dishes",
                newName: "Nutrients_Carbohydrates");

            migrationBuilder.RenameColumn(
                name: "Calories",
                table: "Dishes",
                newName: "Nutrients_Calories");

            migrationBuilder.CreateTable(
                name: "DishMenus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReadyToOrder = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishMenuDishes",
                columns: table => new
                {
                    DishId = table.Column<Guid>(type: "uuid", nullable: false),
                    DishMenuId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishMenuDishes", x => new { x.DishId, x.DishMenuId });
                    table.ForeignKey(
                        name: "FK_DishMenuDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishMenuDishes_DishMenus_DishMenuId",
                        column: x => x.DishMenuId,
                        principalTable: "DishMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishMenuDishes_DishMenuId",
                table: "DishMenuDishes",
                column: "DishMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishMenuDishes");

            migrationBuilder.DropTable(
                name: "DishMenus");

            migrationBuilder.RenameColumn(
                name: "Nutrients_Proteins",
                table: "Dishes",
                newName: "Proteins");

            migrationBuilder.RenameColumn(
                name: "Nutrients_Fats",
                table: "Dishes",
                newName: "Fats");

            migrationBuilder.RenameColumn(
                name: "Nutrients_Carbohydrates",
                table: "Dishes",
                newName: "Carbohydrates");

            migrationBuilder.RenameColumn(
                name: "Nutrients_Calories",
                table: "Dishes",
                newName: "Calories");

            migrationBuilder.AddColumn<Guid>(
                name: "DishesMenuId",
                table: "Dishes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DishesMenus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReadyToOrder = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishesMenus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DishesMenuId",
                table: "Dishes",
                column: "DishesMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishesMenus_DishesMenuId",
                table: "Dishes",
                column: "DishesMenuId",
                principalTable: "DishesMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
