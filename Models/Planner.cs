namespace MealPlannerCSharpApi.Models;

public class Planner
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<Meal> Meals { get; set; } = new List<Meal>();
}
