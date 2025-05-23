using System.Collections.Generic;
using MealPlanner.Model;

namespace MealPlanner.Model
{
    public class Recipe : IRecipe
    {
        public string Name { get; }

        public IReadOnlyDictionary<IIngredient, int> IngredientsNeeded { get; }


        public double SuccessRate { get; }

        public Recipe(string name, IReadOnlyDictionary<IIngredient,int> ingredientsNeeded, double successRate)
        {
            Name = name;

            IngredientsNeeded = ingredientsNeeded;

            SuccessRate = successRate;
        }
        public int CompareTo(IRecipe other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name);
        }
        
    }
}