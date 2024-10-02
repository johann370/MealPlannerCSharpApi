namespace MealPlannerCSharpApi.Models;

public enum MealDay
{
    MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY
}

public enum MealType
{
    BREAKFAST, LUNCH, DINNER
}

public class Meal
{

    public Meal( string mealDay, string mealType)
    {
        this.MealDay = mealDay;
        this.MealType = mealType;
    }

    public long Id { get; set; }
    public string MealDay { get; set; }
    public string MealType { get; set; }
    public List<Recipe>? Recipes { get; set; } = new List<Recipe>();
}
