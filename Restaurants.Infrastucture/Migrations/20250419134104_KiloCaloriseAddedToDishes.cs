using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class KiloCaloriseAddedToDishes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KiloCalorise",
                table: "Dishes",
                newName: "KiloCalories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KiloCalories",
                table: "Dishes",
                newName: "KiloCalorise");
        }
    }
}
