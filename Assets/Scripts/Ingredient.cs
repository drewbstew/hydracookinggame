using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public IngredientType ingredientType;
    public bool requiresCooking;
    
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
        if (!requiresCooking) return;
        
        isCooked = true;
        cookedVisual.SetActive(true);
        rawVisual.SetActive(false);
    }
}