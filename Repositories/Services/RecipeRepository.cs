using MealPlannerCSharpApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MealPlannerCSharpApi.Repositories.Services
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly MealPlannerContext _context;

        public RecipeRepository(MealPlannerContext context)
        {
            _context = context;
        }

        public async Task<Recipe> AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }

        public async void DeleteRecipe(long id)
        {
            var recipe = await _context.Recipes.FindAsync(id);

            if (recipe == null)
            {
                return;
                //TODO: Throw Exception
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<Recipe> GetRecipe(long id)
        {
            var newRecipe = await _context.Recipes.FindAsync(id);

            if(newRecipe == null)
            {
                return null;
                //TODO: Throw Exception
            }

            return newRecipe;
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }
    }
}
