using NUnit.Framework;

namespace RecipeApp.Tests
{
    [TestFixture]
    public class RecipeTests
    {
        [Test]
        public void CalculateTotalCalories_EmptyIngredients_ReturnsZero()
        {
            // Arrange
            Recipe recipe = new Recipe();

            // Act
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(0, totalCalories);
        }

        [Test]
        public void CalculateTotalCalories_SingleIngredient_ReturnsCalories()
        {
            // Arrange
            Recipe recipe = new Recipe();
            Ingredient ingredient = new Ingredient { Name = "Ingredient 1", Quantity = 1, Calories = 100 };
            recipe.AddIngredient(ingredient);

            // Act
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(100, totalCalories);
        }

        [Test]
        public void CalculateTotalCalories_MultipleIngredients_ReturnsTotalCalories()
        {
            // Arrange
            Recipe recipe = new Recipe();
            recipe.AddIngredient(new Ingredient { Name = "Ingredient 1", Quantity = 1, Calories = 100 });
            recipe.AddIngredient(new Ingredient { Name = "Ingredient 2", Quantity = 2, Calories = 150 });

            // Act
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(400, totalCalories); // Total calories: (1 * 100) + (2 * 150) = 400
        }
    }
}
