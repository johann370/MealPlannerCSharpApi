using MealPlannerCSharpApi.Models;

namespace MealPlannerCSharpApi.Repositories
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetRecipes();
        Task<Recipe> GetRecipe(long id);
        Task<Recipe> AddRecipe(Recipe recipe);
        void DeleteRecipe(long id);
    }
}
