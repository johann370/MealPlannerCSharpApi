using MealPlannerCSharpApi.Models;

namespace MealPlannerCSharpApi.Repositories;

public interface IMealRepository
{
    public Task<Meal> GetMeal(long mealId);
    public Task<Meal> CreateMeal(Meal meal);
    public Task<Meal> AddRecipeToMeal(long mealId, long recipeId);
    public void RemoveRecipeFromMeal(long mealId, long recipeId);
}
