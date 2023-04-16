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
        else if (pattyGameObject.GetComponent<Ingredient>().ingredientType == IngredientType.Paddy && pattyGameObject.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.05f)
        {
            //Debug.Log("It's definitely a patty");
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
        var cooked_vis = gameObject.transform.Find("Patty Visuals Cooked").gameObject;
        var raw_vis = gameObject.transform.Find("Patty Visuals Raw").gameObject;

        if (raw_vis)
        {
            //Debug.Log("GRILL TIME");
            cooked_vis.SetActive(true);
            raw_vis.SetActive(false);
        }
    }

}
