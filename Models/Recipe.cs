﻿namespace MealPlannerCSharpApi.Models;

public class Recipe
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string RecipeUrl { get; set; }
    public string ImageUrl { get; set; }
}
