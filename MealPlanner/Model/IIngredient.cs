using System;

namespace MealPlanner.Model
{
    /// <summary>
    /// Represents an ingredient used to cook a meal
    /// Ingridients have a name and type
    /// Ingredients are the same if both the Name and the type are equal
    /// </summary>
    public interface IIngredient : IEquatable<IIngredient>
    {
        //name of the ingredient
        string Name { get; }

        //type of ingredient (produce, dairy, etc.)
        string Type { get; }

    }
}