using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{

    public List<Order> listOfOrders = new List<Order>();

    // Start is called before the first frame update
    public List<Order> GetListOfOrders()
    {
        return listOfOrders;
    }
}
