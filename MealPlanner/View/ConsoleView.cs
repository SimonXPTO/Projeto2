using System.Collections.Generic;
using Spectre.Console;
using MealPlanner.Model;

namespace MealPlanner.View
{
    /// <summary>
    /// View for console that handles the user interaction.
    /// </summary>
    public class ConsoleView : IView
    {
        /// <summary>
        /// Shows the main menu and asks the user to choose an option
        /// </summary>
        /// <returns>The selected option</returns>
        public string ShowMainMenu()
        {
            AnsiConsole.MarkupLine("\n    [bold cyan]#     Hell's Kitchen     #[/]");
            AnsiConsole.MarkupLine("[italic cyan]\"IT'S ****** RAW!\" - " +
                " Gordon Ramsey.[/]\n");

            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose an option")
                    .AddChoices(new[] { "View Ingredients",
                        "View Recipes",
                        "Cook a Meal",
                        "Exit" }));
        }

        /// <summary>
        /// Displays all ingredients in the pantry, and their respective
        /// quantities in a table.
        /// </summary>
        /// <param name="ingredients">Read only dictionary of ingredients and 
        /// quantities</param>
        public void DisplayIngredients(Pantry pantry)
        {
            Table table = new Table();
            table.AddColumn("Name");
            table.AddColumn("Type");
            table.AddColumn("Quantity");

            foreach (IIngredient ingredient in pantry.Ingredients)
            {
                table.AddRow(
                    ingredient.Name,
                    ingredient.Type,
                    pantry.GetQuantity(ingredient).ToString()
                );
            }
            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Displays all recipes and the required ingredients in a table
        /// </summary>
        /// <param name="recipeBook">Read only list of recipes to display</param>
        public void DisplayRecipes(IEnumerable<IRecipe> recipeBook)
        {

            Table table = new Table();
            table.AddColumn("Recipe");
            table.AddColumn("Ingredients Required");

            foreach (IRecipe recipe in recipeBook)
            {
                string list = "";
                foreach (KeyValuePair<IIngredient, int> entry in recipe.IngredientsNeeded)
                {
                    if (list != "")
                        list += ", ";
                    list += entry.Value + "x " + entry.Key.Name;
                }

                table.AddRow(recipe.Name, list);
            }

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Asks the user to select a recipe to cook from the provided list.
        /// </summary>
        /// <param name="recipeBook">Read only list of available recipes</param>
        /// <returns>The name of the selected recipe</returns>
        public string AskForRecipe(IEnumerable<IRecipe> recipeBook)
        {
            List<string> names = new List<string>();
            foreach (IRecipe recipe in recipeBook)
                names.Add(recipe.Name);

            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a recipe to cook")
                    .AddChoices(names));
        }
        /// <summary>
        /// Displays whether you cooked or burned the meal.
        /// </summary>
        /// <param name="message">The result message to show</param>
        public void ShowResults(string message)
        {
            if (message.Contains("succeeded"))
                AnsiConsole.MarkupLine("[green]" + message + "[/]\n\n");
            else
                AnsiConsole.MarkupLine("[red]" + message + "[/]\n\n");
        }

    }
}