using MealPlanner.Model;
using MealPlanner.View;

namespace MealPlanner.Controller 
{
    /// <summary>
    /// Coordinates information between View and Model and invokes 
    /// Model methods to display or cook the recipes.
    /// </summary>
    public class CookingController
    {
        private readonly Pantry pantry;
        private readonly ICook cook;
        private readonly IView view;


        //Initializes the controller with pantry, cook, and view.
        public CookingController(Pantry pantry, ICook cook,
                IView view)
        {
            this.pantry = pantry;
            this.cook = cook;
            this.view = view;
        }

        /// <summary>
        /// Contains the main loop. 
        /// Asks the View to show menus, gets information from the model given 
        /// the user choices and passes it on to the view, and exits on command.
        /// </summary>
        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                string option = view.ShowMainMenu();

                switch (option)
                {
                    case "View Ingredients":
                        view.DisplayIngredients(pantry);
                        break;
                    case "View Recipes":
                        view.DisplayRecipes(cook.RecipeBook);
                        break;
                    case "Cook a Meal":
                        string dishName = view.AskForRecipe(cook.RecipeBook);
                        string result = cook.CookMeal(dishName);
                        view.ShowResults(result);
                        break;
                    case "Exit":
                        exit = true;
                        break;
                }
            }
        }
    }
}