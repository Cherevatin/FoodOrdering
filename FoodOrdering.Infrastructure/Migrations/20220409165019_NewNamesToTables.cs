using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrdering.Infrastructure.Migrations
{
    public partial class NewNamesToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishMenuDishes");

            migrationBuilder.DropTable(
                name: "DishMenus");

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReadyToOrder = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuDish",
                columns: table => new
                {
                    DishId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuDish", x => new { x.DishId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_MenuDish_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuDish_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuDish_MenuId",
                table: "MenuDish",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuDish");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.CreateTable(
                name: "DishMenus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReadyToOrder = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
    }
}
