using MealPlannerCSharpApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlannerCSharpApi.Repositories.Services;

public class MealRepository : IMealRepository
{
    private readonly MealPlannerContext _context;

    public MealRepository(MealPlannerContext context)
    {
        _context = context;
    }
    public async Task<Meal> CreateMeal(Meal meal)
    {
        _context.Meals.Add(meal);
        await _context.SaveChangesAsync();

        return meal;
    }

    public async Task<Meal> GetMeal(long mealId)
    {
        var meal = await _context.Meals.Include(m => m.Recipes).FirstOrDefaultAsync(m => m.Id == mealId);

        if (meal == null)
        {
            return null;
            //TODO: Throw exception
        }

        return meal;
    }

    public async Task<Meal> AddRecipeToMeal(long mealId, long recipeId)
    {
        var meal = await _context.Meals.FindAsync(mealId);
        var recipe = await _context.Recipes.FindAsync(recipeId);

        if (recipe == null || meal == null)
        {
            //TODO: Throw exception
            return null;
        }

        meal.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        return meal;
    }

    public async void RemoveRecipeFromMeal(long mealId, long recipeId)
    {
        var meal = await _context.Meals.Include(m => m.Recipes).FirstOrDefaultAsync(m => m.Id == mealId);
        var recipe = await _context.Recipes.FindAsync(recipeId);

        if(meal == null || recipe == null)
        {
            //TODO: Throw exception
            return;
        }

        meal.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
    }
}
