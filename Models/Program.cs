using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>(); // List to store all recipes

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                // Display menu options
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("2. Display list of recipes");
                Console.WriteLine("3. Display recipe details");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EnterNewRecipe();
                        break;
                    case "2":
                        DisplayRecipeList();
                        break;
                    case "3":
                        DisplayRecipeDetails();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void EnterNewRecipe()
        {
            Recipe recipe = new Recipe();

            // Get recipe name from user
            Console.Write("Enter recipe name: ");
            recipe.Name = Console.ReadLine();

            // Enter ingredients logic
            bool addIngredients = true;
            while (addIngredients)
            {
                Ingredient ingredient = new Ingredient();

                // Get ingredient details from user
                Console.Write("Enter ingredient name (or 'done' to finish): ");
                string name = Console.ReadLine();
                if (name.ToLower() == "done")
                {
                    addIngredients = false;
                    break;
                }
                ingredient.Name = name;

                Console.Write("Enter quantity: ");
                if (!double.TryParse(Console.ReadLine(), out double quantity))
                {
                    Console.WriteLine("Invalid quantity. Please try again.");
                    continue;
                }
                ingredient.Quantity = quantity;

                Console.Write("Enter unit: ");
                ingredient.Unit = Console.ReadLine();

                Console.Write("Enter calories: ");
                if (!int.TryParse(Console.ReadLine(), out int calories))
                {
                    Console.WriteLine("Invalid calories. Please try again.");
                    continue;
                }
                ingredient.Calories = calories;

                Console.Write("Enter food group: ");
                ingredient.FoodGroup = Console.ReadLine();

                recipe.AddIngredient(ingredient);
            }

            // Enter steps logic
            bool addSteps = true;
            while (addSteps)
            {
                Step step = new Step();

                // Get step description from user
                Console.Write("Enter step description (or 'done' to finish): ");
                string description = Console.ReadLine();
                if (description.ToLower() == "done")
                {
                    addSteps = false;
                    break;
                }
                step.Description = description;

                recipe.AddStep(step);
            }

            // Add the recipe to the list
            recipes.Add(recipe);
            Console.WriteLine("Recipe added successfully.");
        }

        static void DisplayRecipeList()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            // Display list of recipe names
            Console.WriteLine("Recipes:");
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }
        }

        static void DisplayRecipeDetails()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            // Display details of a specific recipe
            Console.WriteLine("Choose a recipe to display:");
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }
            string recipeName = Console.ReadLine();

            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            if (selectedRecipe != null)
            {
                Console.WriteLine(selectedRecipe.DisplayRecipe());
                int totalCalories = selectedRecipe.CalculateTotalCalories();
                Console.WriteLine($"Total calories: {totalCalories}");
                if (totalCalories > 300)
                {
                    Console.WriteLine("Warning: Total calories exceed 300!");
                }
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
    }
}
