using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    class Ingredient
    {
        //Here to get name of the ingredients
        public string Name { get; set; }
        //The quantity of the ingredient
        public double Quantity { get; set; }
        //The unit of measure
        public string Unit { get; set; }
        //The number of calories
        public int Calories { get; set; }
        //Groups foods
        public string FoodGroup { get; set; }
    }
}