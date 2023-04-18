using System.Collections.Generic;
using UnityEngine;

public class PrepPlate : MonoBehaviour
{
    [SerializeField] private OrderManager orderManager;
    [SerializeField] private Transform spawnPoint;
    
    private readonly List<Ingredient> currentIngredients = new();
    private readonly List<Ingredient> destroyIngredients = new();
    
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
        foreach (var currentIngredient in currentIngredients)
        {
            destroyIngredients.Add(currentIngredient);
            currentIngredient.gameObject.SetActive(false);
        }
        currentIngredients.Clear();

        // foreach (var destroyIngredient in destroyIngredients)
        // {
        //     currentIngredients.Remove(destroyIngredient);
        // }
        //
        destroyIngredients.Clear();
        
        orderManager.CurrentOrder.Food.InstantiateFoodVisuals(spawnPoint);
    }

    private void FixedUpdate()
    {
        foreach (var ingredient in destroyIngredients)
        {
            Destroy(ingredient);
        }
    }

    private void UpdateUI()
    {
        if (orderManager == null)
        {
            return;
        }
        
        Debug.Log("-------------------------");
        var text = "\n";
        foreach (var orderIngredient in orderManager.CurrentOrder.Food.ingredients)
        {
            text += $"{orderIngredient.ingredientType}";
            var isCooked = false;
            if (!orderIngredient.requiresCooking)
            {
                isCooked = true;
            }
            else if (orderIngredient.isCooked)
            {
                isCooked = true;
            }
        
            var ingredientIsInBoard = currentIngredients.Exists(thisIngredient =>
                thisIngredient.ingredientType == orderIngredient.ingredientType); 
        
            if (ingredientIsInBoard && isCooked)
            {
                text += "+";
            }

            text += " \n ";
            Debug.Log(text);
        }
    }

    private bool CanBeFulfilled()
    {
        return orderManager.CurrentOrder.CanBeFulfilled(currentIngredients);
    }
}
