using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DeliveryBoard : MonoBehaviour
{
    public OrderManager orderManager;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var readyFood = other.gameObject.GetComponent<ReadyFood>();

        if (readyFood == null)
        {
            return;
        }

        if (readyFood.FoodName == orderManager.CurrentOrder.Food.name)
        {
            Destroy(readyFood.gameObject);
            orderManager.GetNewOrder();
        }
    }

}