using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeliveryBoard : MonoBehaviour
{
    [SerializeField] private TMP_Text textMeshPro; 
    
    public OrderManager orderManager;
    private readonly List<Ingredient> currentIngredients = new List<Ingredient>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        var ingredient = other.gameObject.GetComponent<Ingredient>();

        if (ingredient == null)
        {
            return;
        }

        currentIngredients.Add(ingredient);
        UpdateUI();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var ingredient = other.gameObject.GetComponent<Ingredient>();

        if (ingredient == null)
        {
            return;
        }

        currentIngredients.Remove(ingredient);
        CanBeFulfilled();

        UpdateUI();
    }

    private void UpdateUI()
    {
        textMeshPro.text = "";
        foreach (var orderIngredient in orderManager.CurrentOrder.food.ingredients)
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