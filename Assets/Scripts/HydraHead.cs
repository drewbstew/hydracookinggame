using System;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(Rigidbody2D))]
public class HydraHead : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteShapeController;
    [SerializeField] private Transform  headOrigin;
    [SerializeField] private SpriteRenderer headVisuals;
    public Vector2 CurrentVelocity => rigidbody.velocity;

    private Rigidbody2D rigidbody;
    private Rigidbody2D grabbedRigidbody;
    private Transform originalParent;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveHead(Vector2 direction)
    {
        rigidbody.AddForce(direction);
    }

    private void Update()
    {
        spriteShapeController.spline.SetPosition(1, transform.localPosition);
        bool headFlipped = false;
        if (direction.x > 0 && direction.magnitude > 0.1)
        {
            headFlipped = true;
        }
        else if (direction.x < 0 && direction.magnitude > 0.1)
        {
            headFlipped = false;
        }
        else if (direction.magnitude < 0.1)
        {
            return;
        }
        headVisuals.flipX = headFlipped;

    }

    public void Grab()
    {
        var hit = Physics2D.Raycast(transform.position, -Vector2.up, 5f);
        // Grab
        if (hit.collider == null) return;
        grabbedRigidbody = hit.collider.GetComponent<Rigidbody2D>();
        if (grabbedRigidbody == null) return;
        grabbedRigidbody.isKinematic = true;
        
        var rigidBodyTransform = grabbedRigidbody.transform;
        originalParent = rigidBodyTransform.parent;
        rigidBodyTransform.parent = transform;
    }

    public void Release()
    {
        if (grabbedRigidbody == null)  return;
        
        grabbedRigidbody.transform.parent = originalParent;
        grabbedRigidbody.isKinematic = false;
        grabbedRigidbody.velocity = rigidbody.velocity;
        grabbedRigidbody = null;
        originalParent = null;
    }

    public void Initialize()
    {
        spriteShapeController.spline.SetPosition(1, transform.localPosition);
        spriteShapeController.spline.SetPosition(0, headOrigin.localPosition);
    }
}