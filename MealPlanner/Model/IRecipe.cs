using System;
using System.Collections.Generic;


namespace MealPlanner.Model
{
    /// <summary>
    /// Represents a Recipe with required ingredients and respective
    /// quantities to cook a meal.
    /// Recipes are ordered alphabetically. 
    /// </summary>
    public interface IRecipe : IComparable<IRecipe>
    {
        //Name of the meal to cook with the recipe
        string Name { get; }
        //Ingredients and quantities required to cook a meal with this recipe
        IReadOnlyDictionary<IIngredient, int> IngredientsNeeded { get; }
        //Probability of success when trying to cook a meal from this recipe
        double SuccessRate { get; }
    }
}