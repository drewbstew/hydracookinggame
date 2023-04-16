using System.Collections.Generic;
using UnityEngine;

public class PrepPlate : MonoBehaviour
{
    [SerializeField] private OrderManager orderManager;
    [SerializeField] private Transform spawnPoint;
    
    private readonly List<Ingredient> currentIngredients = new();
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var ingredient = other.gameObject.GetComponent<Ingredient>();

        if (ingredient == null)
        {
            return;
        }

        currentIngredients.Add(ingredient);
        CheckIfCanBeFulfilled();
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        var ingredient = other.gameObject.GetComponent<Ingredient>();

        if (ingredient == null)
        {
            return;
        }

        CheckIfCanBeFulfilled();
    }
    
    private void CheckIfCanBeFulfilled()
    {
        if (CanBeFulfilled())
        {
            SpawnReadyOrder();
        }
        UpdateUI();
    }

    private void SpawnReadyOrder()
    {
        orderManager.CurrentOrder.Food.InstantiateFoodVisuals(spawnPoint);
    }

    private void UpdateUI()
    {
        if (orderManager == null)
        {
            return;
        }
        
        // textMeshPro.text = "";
        // foreach (var orderIngredient in orderManager.CurrentOrder.Food.ingredients)
        // {
        //     textMeshPro.text += $"{orderIngredient.ingredientType}";
        //     var isCooked = false;
        //     if (!orderIngredient.requiresCooking)
        //     {
        //         isCooked = true;
        //     }
        //     else if (orderIngredient.isCooked)
        //     {
        //         isCooked = true;
        //     }
        //
        //     var ingredientIsInBoard = currentIngredients.Exists(thisIngredient =>
        //         thisIngredient.ingredientType == orderIngredient.ingredientType); 
        //
        //     if (ingredientIsInBoard && isCooked)
        //     {
        //         textMeshPro.text += "+";
        //     } 
        //     textMeshPro.text += "\n";
        // }
    }

    private bool CanBeFulfilled()
    {
        return orderManager.CurrentOrder.CanBeFulfilled(currentIngredients);
    }
}
