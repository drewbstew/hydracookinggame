using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HydraHead : MonoBehaviour
{
    public Vector2 CurrentVelocity => rigidbody.velocity;
    
    private Rigidbody2D rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveHead(Vector2 direction)
    {
        rigidbody.AddForce(direction);
    }
}