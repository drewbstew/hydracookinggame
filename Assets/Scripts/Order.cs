using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField] public Food food;

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
