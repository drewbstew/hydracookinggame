using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DeliveryBoard : MonoBehaviour
{
    [SerializeField] private TMP_Text textMeshPro; 
    
    public OrderManager orderManager;
    private readonly List<Ingredient> currentIngredients = new();

    private void Start()
    {
        UpdateUI();
    }

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
        // var food = orderManager.
    }

    private void UpdateUI()
    {
        if (orderManager == null)
        {
            return;
        }

        return;
        textMeshPro.text = "";
        foreach (var orderIngredient in orderManager.CurrentOrder.Food.ingredients)
        {
            textMeshPro.text += $"{orderIngredient.ingredientType}";
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
                textMeshPro.text += "+";
            } 
            textMeshPro.text += "\n";
        }
    }

    private bool CanBeFulfilled()
    {
        return orderManager.CurrentOrder.CanBeFulfilled(currentIngredients);
    }
}