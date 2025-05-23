using System;
using MealPlanner.Controller;
using MealPlanner.Model;
using MealPlanner.View;


namespace MealPlanner {
    public class Program {

        //Parses command line arguments, initializes the model
        //and starts the controller loop.
        private static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Error! command should be: dotnet run --project" +
                " MealPlanner -- <ingredients.txt> <recipe1.txt> <recipe2.txt> ...");
                Environment.Exit(-1);
            }

            //args[0] = materials, args[1], args[2], etc = recipes
            string[] recipeFiles = new string[args.Length - 1];
            for (int i = 1; i < args.Length; i++)
                recipeFiles[i - 1] = args[i];

            Pantry pantry = new Pantry();
            pantry.LoadIngredientsFile(args[0]);

            ICook cook = new Cook(pantry);
            cook.LoadRecipeFiles(recipeFiles);

            IView view = new ConsoleView();
            CookingController controller = new CookingController(
                pantry, cook, view);
            controller.Run();

        }
    }
}
