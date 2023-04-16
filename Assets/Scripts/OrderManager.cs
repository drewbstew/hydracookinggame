using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private List<Food> possibleFoods = new List<Food>();
    
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
        var food = possibleFoods[Random.Range(0, possibleFoods.Count - 1)];
        return new Order(food);
    }

}
