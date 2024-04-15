/*method for creating recipe
 * method for creating, viewing, scaling, clearing, resetting recipe
 * call these methods in main method
 * use conditional or switch cases
 * use a menu-use part 3 2023 as a reference-welcome message
 
*/
using System;

namespace RecipeApplication
{
    
    class Ingredient
    {
        //put getters and setters in place to populate varibales https://www.w3schools.com/cs/cs_properties.php
        public string Name { get; set; }
        public double OriginalQuantity { get; set; }
        public double NewQuantity { get; set; }
        public string Unit { get; set; }
    }

    class RecipeStep
    {
        public string Steps { get; set; }
    }

    class Recipe
    {
        //create the arrays
        public Ingredient[] originalIngredients;
        public Ingredient[] ingredients;
        public RecipeStep[] steps;

        public Recipe()
        {
            //initialize the arrays 
            ingredients = new Ingredient[0];
            steps = new RecipeStep[0];
        }

        public void CreateRecipe()
        {
            Console.WriteLine("Enter details for the recipe\n_____________________________________");

            Console.Write("Enter number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());
            //sets the number of elements to be stored in the arrays
            //https://stackoverflow.com/questions/230454/how-to-fill-an-array-from-user-input-c
            ingredients = new Ingredient[ingredientCount];
            originalIngredients = new Ingredient[ingredientCount];

            for (int i = 0; i < ingredientCount; i++)
            //loops for the amount of ingredients that need to be entered https://stackoverflow.com/questions/230454/how-to-fill-an-array-from-user-input-c
            {
                Console.WriteLine($"Enter ingredient details {i + 1}:");
                Console.Write("Ingredient name: ");
                string name = Console.ReadLine();

                Console.Write("Ingredient quantity: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();
                //stores the captured data into the arrays
                //https://stackoverflow.com/questions/6482331/how-to-add-different-types-of-objects-in-a-single-array-in-c
                ingredients[i] = new Ingredient { Name = name, NewQuantity = quantity, Unit = unit };
                originalIngredients[i] = new Ingredient { Name = name, OriginalQuantity = quantity, Unit = unit };
            }

            Console.Write("Enter number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());
            //sets the size of the array https://www.w3schools.com/cs/cs_properties.php
            steps = new RecipeStep[stepCount];
            //loops for the amount of steps that need to be entered https://www.w3schools.com/cs/cs_arrays_loop.php
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                steps[i] = new RecipeStep { Steps = step };
            }
            //changes the colour of the font
            //https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nNew recipe created! Look at you MasterChef =)");
            Console.ResetColor();
            DisplayRecipe();
        }

        public void DisplayRecipe()
        {
        //https://www.w3schools.com/cs/cs_conditions.php
            if (ingredients == null || ingredients.Length == 0)
            {
                //message to be displayed if the arrays are empty
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipe to display");
            }
            else
            {
                //displays the recipe stored in the array
                Console.WriteLine("\nRecipe details:");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in ingredients)
                {
                    //https://stackoverflow.com/questions/16265247/printing-all-contents-of-array-in-c-sharp
                    Console.WriteLine($"{ingredient.NewQuantity} {ingredient.Unit} of {ingredient.Name}");
                }
                //\n leaves a line when displaying the output
                Console.WriteLine("\nSteps:");
                for (int i = 0; i < steps.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {steps[i].Steps}");
                }
            }
            //resets the original colour of the output
            Console.ResetColor();
        }

        public void ScaleRecipe(double sAmount)
        {
            foreach (var ingredient in ingredients)
            if (ingredients == null || ingredients.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //message to be displayed if theres no recipe to scale
                Console.WriteLine("No recipe to scale.");
                Console.ResetColor();
                return;
            }
            else
            {
                for (int i = 0;i < steps.Length; i++)
                {
                   ingredient.OriginalQuantity *= sAmount;
                        ingredient.NewQuantity = sAmount;

                }


                //message to be displayed if the scale is successful 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Recipe scaled successfully.");
                DisplayRecipe();
                Console.ResetColor();
            }
        }

        public void ResetQuantities()
        {
            if (originalIngredients == null || originalIngredients.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //message to be displayed if no quantities have been scaled
                Console.WriteLine("No original recipe to reset.");
                Console.ResetColor();
                return;
            }
            else
            {
                //loops for the number on quantities there are and resets them 
                for (int i = 0; i < ingredients.Length; i++)
                {
                    //https://stackoverflow.com/questions/39495995/c-sharp-reset-an-array-to-its-initialized-values
                    //https://www.codecademy.com/resources/docs/c-sharp/arrays/clear
                    ingredients[i].NewQuantity = originalIngredients[i].OriginalQuantity;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Quantities reset.");
                DisplayRecipe();
                Console.ResetColor();
            }
        }

        public void ClearRecipe()
        {
            if (ingredients == null || ingredients.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //message to be displayed if no recipe is found
                Console.WriteLine("No recipe found.");
                Console.ResetColor();
                return;
            }
            else
            {
                //clears the arrays by making them 0
                //https://www.tutorialspoint.com/How-do-you-empty-an-array-in-Chash
                ingredients = new Ingredient[0];
                steps = new RecipeStep[0];

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Recipe cleared.");
                Console.ResetColor();
            }
        }

        static void Main(string[] args)
        {
            //create an instance of Recipe
            Recipe recipe = new Recipe();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Recipe Book!");
            Console.ResetColor();
            //https://dotnettutorials.net/lesson/do-while-loop-in-csharp/
            do
            {
                //do loop to loop the menu until user exits
                Console.WriteLine("\nSelect a function:");
                Console.WriteLine("(1) Create a new recipe");
                Console.WriteLine("(2) Display recipe");
                Console.WriteLine("(3) Scale recipe");
                Console.WriteLine("(4) Reset quantities");
                Console.WriteLine("(5) Clear recipe");
                Console.WriteLine("(6) Quit");

                string option = Console.ReadLine();
                //reads user input from the menu
                //uses switch cases to execute the various menu options
                //https://stackoverflow.com/questions/43898227/create-menu-with-switch-statement-loop-and-list
                switch (option)
                {
                    case "1":
                        recipe.CreateRecipe();
                        //break will break the loop
                        break;
                    case "2":
                        recipe.DisplayRecipe();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        //user can choose to scale by 0.5, 2, or 3
                        Console.WriteLine("Enter factor to scale recipe by:");
                        int sAmount = Convert.ToInt32(Console.ReadLine());
                        recipe.ScaleRecipe(sAmount);
                        recipe.DisplayRecipe();
                        Console.ResetColor();
                        break;
                    case "4":
                        recipe.ResetQuantities();
                        break;
                    case "5":
                        recipe.ClearRecipe();
                        break;
                    case "6":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Happy cooking!");
                        Console.ResetColor();
                        //exits the application
                        return;
                    default:
                        //error message if the user enters a number out of the 1-6 range
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please select from options 1-6.");
                        break;
                }
                //while(true) will keep the application looping until the user exits
            } while (true);
        }
    }
}




