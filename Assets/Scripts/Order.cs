using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public Food Food => food;
    private readonly Food food;

    public Order(Food food)
    {
        this.food = food;
    }

    public bool CanBeFulfilled(List<Ingredient> ingredients)
    {
        if (ingredients.Count < food.ingredients.Count)
        {
            return false;
        }

        foreach (var foodIngredient in food.ingredients)
        {
            var foundIngredient = ingredients.Find(ingredient => ingredient.ingredientType == foodIngredient.ingredientType);
            if (!foundIngredient)
            {
                return false;
            }

            if (foundIngredient.requiresCooking && !foundIngredient.isCooked)
            {
                return false;
            }
            
        }

        return true;
    }
}
