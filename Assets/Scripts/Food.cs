using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Food", order = 1)]

public class Food : ScriptableObject
{
    public List<Ingredient> ingredients = new();
    public Sprite finishedVisuals;
    public SpriteRenderer finishedObject;
    bool isComplete = false;

    public bool Contains(Ingredient item)
    {
        return ingredients.Contains(item);
    }

    public GameObject InstantiateFoodVisuals(Transform instantiatedTransform)
    {
        var instantiatedFood = Instantiate(finishedObject, instantiatedTransform.position, Quaternion.identity);
        instantiatedFood.sprite = finishedVisuals;
        return instantiatedFood.gameObject;
    }
}
