using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Food", order = 1)]

public class Food : ScriptableObject
{
    public List<Ingredient> ingredients = new List<Ingredient>();
    bool isComplete = false;
}
