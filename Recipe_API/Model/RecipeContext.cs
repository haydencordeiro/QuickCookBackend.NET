using Microsoft.EntityFrameworkCore;

namespace Recipe_API.Model
{
    public class RecipeContext: DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public RecipeContext(DbContextOptions options) : base(options)
        {

        }
    }
}
