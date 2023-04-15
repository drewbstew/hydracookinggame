using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    public bool isCooked;
    public GameObject cookedVisual;
    public GameObject rawVisual;

    // Start is called before the first frame update
    void Start()
    {
        cookedVisual.SetActive(isCooked);
        rawVisual.SetActive(!isCooked);
    }

    public void Cook()
    {
        isCooked = true;
        cookedVisual.SetActive(true);
        rawVisual.SetActive(false);
    }
}


