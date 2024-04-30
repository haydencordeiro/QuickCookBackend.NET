using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PexelsDotNetSDK.Api;
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
        public async Task<IActionResult> AddRecipes([FromBody] Recipe recipe)
        {

            // Update the picture URL
            // This key is no longer valid
            var pexelsClient = new PexelsClient("EIDVYfVDpZYe1ueHK35rSOhxC75WjFhqqapoiwRXcj6pw8NOcqNnjeZS");
            var result = await pexelsClient.SearchPhotosAsync(recipe.Title);
            recipe.Picture = result.photos[0].url;

            _db.Recipes.Add(recipe);
            await _db.SaveChangesAsync();

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
            //recipe.Title = updatedRecipe.Title;
            //recipe.RecipeURL = updatedRecipe.RecipeURL;
            //recipe.UpdatedDate = updatedRecipe.UpdatedDate;
            _db.SaveChanges();

            return Ok(recipe);
        }
    }
}
