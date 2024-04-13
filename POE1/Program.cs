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

   