using MealPlannerCSharpApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlannerCSharpApi.Repositories.Services;

public class PlannerRepository : IPlannerRepository
{
    private readonly MealPlannerContext _context;

    public PlannerRepository(MealPlannerContext context)
    {
        _context = context;
    }

    //TODO: Throw exceptions

    public async Task<Planner> CreatePlanner(Planner planner)
    {
        foreach (var mealDay in Enum.GetNames(typeof(MealDay)))
        {

            foreach (var mealType in Enum.GetNames(typeof(MealType)))
            {
                var meal =_context.Meals.Add(new Meal(mealDay, mealType)).Entity;
                await _context.SaveChangesAsync();
                planner.Meals.Add(meal);
            }
        }

        _context.Planners.Add(planner);
        await _context.SaveChangesAsync();

        return planner;
    }

    public async void DeletePlanner(long plannerId)
    {
        var planner = await _context.Planners.FindAsync(plannerId);

        if (planner == null)
        {
            return;
        }

        _context.Planners.Remove(planner);
        await _context.SaveChangesAsync();
    }

    public async Task<Planner> GetPlanner(long plannerId)
    {
        var planner = await _context.Planners.Include(p => p.Meals).ThenInclude(meal => meal.Recipes).FirstOrDefaultAsync(p => p.Id == plannerId);

        if (planner == null)
        {
            return null;
        }

        return planner;
    }
}
