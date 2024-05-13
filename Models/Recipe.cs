using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        // Adds an ingredient to the recipe
        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        // Adds a step to the recipe
        public void AddStep(Step step)
        {
            Steps.Add(step);
        }

        // Displays the recipe including ingredients and steps
        public string DisplayRecipe()
        {
            string recipeString = $"Recipe: {Name}\n";
            recipeString += "Ingredients:\n";
            foreach (var ingredient in Ingredients)
            {
                recipeString += $"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}\n";
            }
            recipeString += "\nSteps:\n";
            for (int i = 0; i < Steps.Count; i++)
            {
                recipeString += $"{i + 1}. {Steps[i].Description}\n";
            }
            return recipeString;
        }

        // Calculates the total calories of all ingredients in the recipe
        public int CalculateTotalCalories()
        {
            return Ingredients.Sum(i => i.Calories);
        }

        // Checks if the total calories exceed 300 and notifies the user
        public void CheckTotalCalories()
        {
            int totalCalories = CalculateTotalCalories();
            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: Total calories exceed 300!");
            }
        }
    }
}
