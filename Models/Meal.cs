namespace MealPlannerCSharpApi.Models;

public class Meal
{
    public long Id { get; set; }
    public string MealDay { get; set; }
    public string MealType { get; set; }
    public List<Recipe>? Recipes { get; set; } = new List<Recipe>();
}
