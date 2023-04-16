using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Food", order = 1)]

public class Food : ScriptableObject
{
    public List<Ingredient> ingredients = new();
    public Sprite finishedVisuals;
    public ReadyFood readyFood;

    public void InstantiateFoodVisuals(Transform instantiatedTransform)
    {
        var instantiatedFood = Instantiate(readyFood, instantiatedTransform.position, Quaternion.identity);
        instantiatedFood.Initialize(this);
    }
}
