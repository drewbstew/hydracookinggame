using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        var pattyGameObject = other.gameObject;
        if (pattyGameObject == null)
        {
            return;
        }
        else if (pattyGameObject.GetComponent<Ingredient>().ingredientType == IngredientType.Paddy)
        {
            GrillCheckAndFire(pattyGameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GrillCheckAndFire(GameObject gameObject)
    {
        var cooked_vis = gameObject.transform.Find("Patty Visuals Cooked").GetComponent<SpriteRenderer>();
        var raw_vis = gameObject.transform.Find("Patty Visuals Raw").GetComponent<SpriteRenderer>();

        if (raw_vis.enabled == true)
        {
            raw_vis.enabled = false;
            cooked_vis.enabled = true;
        }
    }

}
