using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrdering.Infrastructure.Migrations
{
    public partial class FixProblems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "Weight_MesurementUnit",
                table: "Dishes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight_Value",
                table: "Dishes",
                type: "double precision",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight_MesurementUnit",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Weight_Value",
                table: "Dishes");

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Dishes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
