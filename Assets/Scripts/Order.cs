using System.Collections.Generic;
using UnityEngine;

public class Order: MonoBehaviour
{
    public Food Food => food;
    private readonly Food food;

    public Order(Food food)
    {
        this.food = food;
    }

    public bool CanBeFulfilled(List<Ingredient> ingredients)
    {
        if (ingredients.Count != food.ingredients.Count)
        {
            return false;
        }
        
        
        foreach (var deliverIngredient in ingredients)
        {
            if (!deliverIngredient.isCooked && deliverIngredient.requiresCooking)
            {
                return false;
            }

            var deliveredIngredientExists = food.ingredients.Exists(foodIngredient => foodIngredient.ingredientType == deliverIngredient.ingredientType);
            if (!deliveredIngredientExists)
            {
                return false;
            }
        }

        return true;
    }
}
