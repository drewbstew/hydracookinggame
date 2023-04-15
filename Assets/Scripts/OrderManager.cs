using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private List<Order> possibleOrders = new List<Order>();
    
    public Order CurrentOrder { get; private set; }

    private void Update()
    {
        if (CurrentOrder == null)
        {
            CurrentOrder = GetRandomOrder();
        }
    }

    private Order GetRandomOrder()
    {
        return possibleOrders[Random.Range(0, possibleOrders.Count - 1)];
    }

}
