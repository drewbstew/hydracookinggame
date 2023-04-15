using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{

    public List<Food> listOfOrders = new List<Food>();

    // Start is called before the first frame update
    public List<Food> GetListOfOrders()
    {
        return listOfOrders;
    }
}
