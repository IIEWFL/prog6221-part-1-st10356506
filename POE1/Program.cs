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
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }

    class RecipeStep
    {
        public string Steps { get; set; }
    }

    class Recipe
    {
        public Ingredient[] ingredients;
        public RecipeStep[] steps;

        public Recipe()
        {
            ingredients = new Ingredient[0];
            steps = new RecipeStep[0];
        }

        public void CreateRecipe()
        {
            Console.WriteLine("Enter details for the recipe:");

            Console.Write("Enter number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());
            ingredients = new Ingredient[ingredientCount];
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter ingredient details {i + 1}:");
                Console.Write("Ingredient name: ");
                string name = Console.ReadLine();
                Console.Write("Ingredient quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();
                ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            }

            Console.Write("Enter number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());
            steps = new RecipeStep[stepCount];
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                steps[i] = new RecipeStep { Steps = step };
            }

            Console.WriteLine("Recipe created successfully.");
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe details:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Steps}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }

            Console.WriteLine("Recipe scaled successfully.");
        }

        public void ResetQuantities()
        {
            // Reset quantities to their original values
            Console.WriteLine("Quantities reset successfully.");
        }

       