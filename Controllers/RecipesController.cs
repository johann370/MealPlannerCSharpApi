namespace MealPlannerCSharpApi.Controllers;

using MealPlannerCSharpApi.Models;
using MealPlannerCSharpApi.Repositories;
using MealPlannerCSharpApi.Repositories.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeRepository _repository;

    public RecipesController(IRecipeRepository repository)
    {
        _repository = repository;
    }

    //TODO: Catch exceptions

    [HttpGet]
    public async Task<ActionResult<List<Recipe>>> GetRecipes()
    {
        return await _repository.GetRecipes();
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> AddRecipe(Recipe recipe)
    {
        var newRecipe = await _repository.AddRecipe(recipe);

        return CreatedAtAction(nameof(GetRecipe), new { recipeId = newRecipe.Id}, newRecipe);
    }

    [HttpGet("{recipeId}")]
    public async Task<ActionResult<Recipe>> GetRecipe(long recipeId)
    {
        return await _repository.GetRecipe(recipeId);
    }

    [HttpDelete("{recipeId}")]
    public async Task<IActionResult> DeleteRecipe(long recipeId)
    {
        _repository.DeleteRecipe(recipeId);
        return NoContent();
    }
}
