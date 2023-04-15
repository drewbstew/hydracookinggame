using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : ScriptableObject
{
    public List<Ingredient> ingredients = new List<Ingredient>();
    bool isComplete = false;
}
