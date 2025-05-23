using System.Collections.Generic;
using MealPlanner.Model;

namespace MealPlanner.View
{
    public interface IView
    {
        string ShowMainMenu();
        void DisplayIngredients(Pantry pantry);
        void DisplayRecipes(IEnumerable<IRecipe> recipes);
        string AskForRecipe(IEnumerable<IRecipe> recipes);
        void ShowResults(string message);
    }
}