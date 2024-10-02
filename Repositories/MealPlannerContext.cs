using MealPlannerCSharpApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlannerCSharpApi.Repositories
{
    public class MealPlannerContext : DbContext
    {
        public MealPlannerContext(DbContextOptions<MealPlannerContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Planner> Planners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .HasMany(e => e.Recipes)
                .WithMany();
        }
    }
}
