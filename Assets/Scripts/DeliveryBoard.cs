using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBoard : MonoBehaviour
{
    public OrderManager orderManager;
    private List<Ingredient> currentIngredients = new List<Ingredient>();
    bool CanBeFulfilled;

    private void OnTriggerEnter2D(Collider2D other) {
        var ingredient = other.gameObject.GetComponent<Ingredient>();

        if (ingredient==null){return;}

        currentIngredients.Add(ingredient);

        List<Order> orderList = new List<Order>();
        orderList = orderManager.GetListOfOrders();
        foreach (Order order in orderList)
        {
            if (order.CanBeFulfilled(order.GetOrder().ingredients))
            {
                Debug.Log("Order Fulfilled!");
                CanBeFulfilled = true;
            }
        }
    }
    
}
