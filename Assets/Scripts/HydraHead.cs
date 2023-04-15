using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HydraHead : MonoBehaviour
{
    public Vector2 CurrentVelocity => rigidbody.velocity;

    // [SerializeField] private float grabbingForce;

    private Rigidbody2D rigidbody;
    private GameObject grabbedObject;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveHead(Vector2 direction)
    {
        rigidbody.AddForce(direction);
    }

    public void Grab()
    {
        Debug.Log(transform.position);
        var hit = Physics2D.Raycast(transform.position, -Vector2.up, 5f);

        // Grab
        if (hit.collider == null) return;
        var rigidBody = hit.collider.GetComponent<Rigidbody2D>();
        if (rigidBody == null) return;
        grabbedObject = hit.collider.gameObject;
        rigidBody.isKinematic = true;
        grabbedObject.transform.parent = transform;
    }

    public void Release()
    {
        grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}