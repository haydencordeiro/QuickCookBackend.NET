using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe_API.Model;

namespace Recipe_API.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeContext _db;
        public RecipeController(RecipeContext db) {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> getRecipes()
        {
            return Ok(_db.Recipes);
        }

        [HttpPost]
        public ActionResult<Recipe> addRecipes([FromBody]Recipe recipe)
        {
            Recipe tempRecipe = new Recipe();
            tempRecipe.Title = "test Title";
            tempRecipe.RecipeURL = "https://www.youtube.com/watch?v=suXQ2mPfhSg"; 
            _db.Recipes.Add(tempRecipe);
            _db.SaveChanges();

            return Ok(recipe);
        }


        [HttpDelete("{id:int}", Name ="DeleteRecipe")]
        public ActionResult<Recipe> deleteRecipe(int id)
        {
            var recipe = _db.Recipes.FirstOrDefault(u => u.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            _db.Recipes.Remove(recipe);
            _db.SaveChanges();

            return NoContent();
        }


        [HttpPut("{id:int}", Name= "UpdateRecipe")]
        public ActionResult<Recipe> updateRecipe(int id, [FromBody] Recipe updatedRecipe)
        {
            var recipe = _db.Recipes.FirstOrDefault(u => u.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            recipe.Title = updatedRecipe.Title;
            recipe.RecipeURL = updatedRecipe.RecipeURL;
            recipe.UpdatedDate = updatedRecipe.UpdatedDate;
            //_db.Recipes.Remove(recipe);
            _db.SaveChanges();

            return Ok(recipe);
        }
    }
}
