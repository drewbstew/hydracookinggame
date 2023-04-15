using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<Ingredient> ingredients;
    public float delay_between_spawn_min;
    public float delay_between_spawn_max;

    private void Start() {
        StartCoroutine(IngredientSpawnTimer());
    }

    void SpawnIngredient()
    {
        var ingredient = ingredients[Random.Range(0,ingredients.Count)];
        Object.Instantiate(ingredient, this.transform);
    }

    IEnumerator IngredientSpawnTimer()
    {
        while (true)
        {
            SpawnIngredient();
            yield return new WaitForSeconds(Random.Range(delay_between_spawn_min,delay_between_spawn_max));
        }
    }

}
