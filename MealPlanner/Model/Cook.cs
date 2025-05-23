using System;
using System.Collections.Generic;

namespace MealPlanner.Model
{
    /// <summary>
    /// Implementation of ICook. 
    /// </summary>
    public class Cook : ICook
    {
        private readonly Pantry pantry;
        private readonly List<IRecipe> recipeBook;

        public Cook(Pantry pantry)
        {
            this.pantry = pantry;
            recipeBook = new List<IRecipe>();
        }

        /// <summary>
        /// returns a read only list of loaded recipes.
        /// </summary>
        public IEnumerable<IRecipe> RecipeBook => recipeBook;

        /// <summary>
        /// Loads recipes from the files.
        /// Must parse the name, success rate, needed ingredients and
        /// necessary quantities.
        /// </summary>
        /// <param name="recipeFiles">Array of file paths</param>
        public void LoadRecipeFiles(string[] recipeFiles)
        {
            //Implement Me
        }

        /// <summary>
        /// Attempts to cook a meal from a given recipe. Consumes pantry 
        /// ingredients and returns the result message.
        /// </summary>
        /// <param name="recipeName">Name of the recipe to cook</param>
        /// <returns>A message indicating success, failure, or error</returns>
        public string CookMeal(string recipeName)
        {
            IRecipe selected = null;

            for (int i = 0; i < recipeBook.Count; i++)
            {
                if (recipeBook[i].Name.Equals(recipeName,
                        StringComparison.OrdinalIgnoreCase))
                {
                    selected = recipeBook[i];
                    break;
                }
            }
            
            if (selected == null)
                return "Recipe not found.";

            foreach (KeyValuePair<IIngredient, int> needed in selected.IngredientsNeeded)
            {
                IIngredient ingredient = needed.Key;
                int need = needed.Value;
                int have = pantry.GetQuantity(ingredient);
                if (have < need)
                {
                    if (have == 0)
                        return "Missing ingredient: " + ingredient.Name;
         
                    return "Not enough " + ingredient.Name +
                           " (need " + need + ", have " + have + ")";
                }
            }

            foreach (KeyValuePair<IIngredient, int> needed in selected.IngredientsNeeded)
                if (!pantry.ConsumeIngredient(needed.Key, needed.Value))
                    return "Not enough ingredients";

            Random rng = new Random();
            if (rng.NextDouble() < selected.SuccessRate)
                return "Cooking '" + selected.Name + "' succeeded!";
            else
                return "Cooking '" + selected.Name + "' failed. Ingredients burned...";

        }
    }
}