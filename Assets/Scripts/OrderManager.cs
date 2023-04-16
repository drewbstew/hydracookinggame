using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private List<Food> possibleFoods = new();
    [SerializeField] private SpriteRenderer orderVisualsPivot;
    
    public Order CurrentOrder { get; private set; }

    private void Update()
    {
        if (CurrentOrder == null)
        {
            CurrentOrder = GetRandomOrder();
        }
    }

    public void GetNewOrder()
    {
        CurrentOrder = null;
    }

    private Order GetRandomOrder()
    {
        var food = possibleFoods[Random.Range(0, possibleFoods.Count - 1)];
        orderVisualsPivot.sprite = food.finishedVisuals;
        return new Order(food);
    }

}
