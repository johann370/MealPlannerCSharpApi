using MealPlannerCSharpApi.Models;
using MealPlannerCSharpApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MealPlannerCSharpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MealsController : ControllerBase
{
    private readonly IMealRepository _mealRepository;

    public MealsController(IMealRepository mealRepository)
    {
        _mealRepository = mealRepository;
    }

    //TODO: Catch exceptions

    [HttpPost]
    public async Task<ActionResult<Meal>> CreateMeal(Meal meal)
    {
        var newMeal = await _mealRepository.CreateMeal(meal);
        return CreatedAtAction(nameof(GetMeal), new { mealId = newMeal.Id }, newMeal);
    }


    [HttpGet("{mealId}")]
    public async Task<ActionResult<Meal>> GetMeal(long mealId)
    {
        return await _mealRepository.GetMeal(mealId);
    }

    [HttpPut("{mealId}/recipes/{recipeId}")]
    public async Task<ActionResult<Meal>> AddRecipeToMeal(long mealId, long recipeId)
    {
        return await _mealRepository.AddRecipeToMeal(mealId, recipeId);
    }

    [HttpDelete("{mealId}/recipes/{recipeId}")]
    public async Task<IActionResult> RemoveRecipeFromMeal(long mealId, long recipeId)
    {
        _mealRepository.RemoveRecipeFromMeal(mealId, recipeId);
        return NoContent();
    }
}
