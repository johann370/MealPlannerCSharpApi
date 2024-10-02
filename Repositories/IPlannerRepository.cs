using MealPlannerCSharpApi.Models;

namespace MealPlannerCSharpApi.Repositories;

public interface IPlannerRepository
{
    public Task<Planner> GetPlanner(long plannerId);
    public Task<Planner> CreatePlanner(Planner planner);
    public void DeletePlanner(long plannerId);
}
