using MealPlannerCSharpApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlannerCSharpApi.Repositories
{
    public class MealPlannerContext : DbContext
    {
        public MealPlannerContext(DbContextOptions<MealPlannerContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; } = null!;
    }
}
