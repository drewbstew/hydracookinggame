using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Order : MonoBehaviour
{
    public Food food;
    public bool isComplete = false;

    public Food GetOrder()
    {
        return food;
    }

    public bool CanBeFulfilled(List<Ingredient> ingredients)
    {
        return ingredients.Intersect(food.ingredients).Any();
    }
}
