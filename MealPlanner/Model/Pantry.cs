using System.Collections.Generic;


namespace MealPlanner.Model
{
    /// <summary>
    /// The Pantry contains all the ingredients and 
    /// respective quantities that can be used to cook meals.
    /// </summary>
    public class Pantry
    {
        /// <summary>
        /// Dictionary that contains all the ingredients in the pantry
        /// and the respective amount
        /// </summary>
        private readonly Dictionary<IIngredient, int> ingredients;

        public Pantry()
        {
            ingredients = new Dictionary<IIngredient, int>();
        }

        /// <summary>
        /// Provides all ingredients in the pantry.
        /// </summary>
        public IEnumerable<IIngredient> Ingredients => ingredients.Keys;

        // <summary>
        /// provides the amount of the specified ingredient in the pantry.
        /// </summary>
        /// <param name="ingredient">The ingredient to view the amount.</param>
        /// <returns>The quantity in the pantry, or 0 if not contained</returns>
        public int GetQuantity(IIngredient ingredient) =>
            ingredients.ContainsKey(ingredient) ? ingredients[ingredient] : 0;


        /// <summary>
        /// Adds or replaces the quantity for a specific ingredient
        /// </summary>
        /// <param name="ingredient">The ingredient to add</param>
        /// <param name="quantity">The new amount to set</param>
        public void AddIngredient(IIngredient ingredient, int quantity)
        {
            if (quantity <= 0)
                return;

            if (ingredients.ContainsKey(ingredient))
                ingredients[ingredient] += quantity;
            else
                ingredients.Add(ingredient, quantity);
        }

        /// <summary>
        /// Removes a given amount of an ingredient from the pantry
        /// If there's not enough of that ingredient it is not consumed.
        /// </summary>
        /// <param name="ingredient">The ingredient we want to consume</param>
        /// <param name="quantity">The amount to remove</param>
        /// <returns>True if consumed successfuly, false if there's none in the 
        /// pantry or if there's not enough quantity</returns>
        public bool ConsumeIngredient(IIngredient ingredient, int quantity)
        {
            if (ingredients.ContainsKey(ingredient))
            {
                if (ingredients[ingredient] >= quantity)
                {
                    ingredients[ingredient] -= quantity;
                    if (ingredients[ingredient] == 0)
                        ingredients.Remove(ingredient);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get all the ingredients in the pantry.
        /// </summary>
        /// <returns>A read only dictionary of ingredients</returns>
        public IReadOnlyDictionary<IIngredient, int> GetAllIngredients()
        {
            return ingredients;
        }

        /// <summary>
        /// Search and return an ingredient by name.
        /// </summary>
        /// <param name="name">The name of the ingredient</param>
        /// <returns>The ingredient if it exists, if not returns null</returns>
        public IIngredient GetIngredient(string name)
        {
            foreach (IIngredient ing in ingredients.Keys)
                if (ing.Name.Equals(name))
                    return ing;

            return null;
        }

        /// <summary>
        /// Loads the ingredients and their quantities from the text file.
        /// </summary>
        /// <param name="file">Path to the ingredients file</param>
        public void LoadIngredientsFile(string file)
        {
            string[] lines = System.IO.File.ReadAllLines(file);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string type = parts[1].Trim();
                    IIngredient ingredient = new Ingredient(name, type);
                    if (ingredients.ContainsKey(ingredient))
                    {
                        ingredients[ingredient] += 1;
                    }
                    else
                    {
                        ingredients.Add(ingredient, 1);
                    }
            
                }
            }
        }
    }
}
