using UnityEngine;

public class ReadyFood : MonoBehaviour
{
    public string FoodName => foodName;
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    private string foodName;

    public void Initialize(Food food)
    {
        spriteRenderer.sprite = food.finishedVisuals;
        foodName = food.name;
    }
    
    
}
