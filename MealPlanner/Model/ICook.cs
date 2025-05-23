using System.Collections.Generic;

namespace MealPlanner.Model
{
    /// <summary>
    /// Defines methods for loading recipes and cooking meals
    /// </summary>
    public interface ICook
    {
        //list of recipes
        IEnumerable<IRecipe> RecipeBook { get; }
        void LoadRecipeFiles(string[] recipeFiles);
        string CookMeal(string recipeName);
    }
}
