using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrdering.Infrastructure.Migrations
{
    public partial class AddNamePropertyToDishEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Dishes");
        }
    }
}
