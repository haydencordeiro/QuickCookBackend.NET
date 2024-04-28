using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe_API.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipeBody",
                table: "Recipes",
                newName: "RecipeURL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipeURL",
                table: "Recipes",
                newName: "RecipeBody");
        }
    }
}
