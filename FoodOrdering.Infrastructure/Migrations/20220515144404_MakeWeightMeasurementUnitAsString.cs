using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrdering.Infrastructure.Migrations
{
    public partial class MakeWeightMeasurementUnitAsString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Weight_MesurementUnit",
                table: "Dishes",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weight_MesurementUnit",
                table: "Dishes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
