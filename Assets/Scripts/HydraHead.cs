using System;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(Rigidbody2D))]
public class HydraHead : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteShapeController;
    [SerializeField] private Transform  headOrigin;
    [SerializeField] private SpriteRenderer headVisuals;
    [SerializeField] private AudioClip grabbingSound;
    [SerializeField] private Sprite headSprite; // New serialized field for head sprite asset
    public Vector2 CurrentVelocity => rigidbody.velocity;

    private Rigidbody2D rigidbody;
    private Rigidbody2D grabbedRigidbody;
    private Transform originalParent;
    private int currentPlayer = 0;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveHead(Vector2 direction)
    {
        rigidbody.AddForce(direction);
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

    private void Update()
    {
        spriteShapeController.spline.SetPosition(1, transform.localPosition);

    }

    public void Grab()
    {
        if (grabbedRigidbody != null) return;
        var hit = Physics2D.Raycast(transform.position, -Vector2.up, 5f);
        // Grab
        if (hit.collider == null) return;
        grabbedRigidbody = hit.collider.GetComponent<Rigidbody2D>();
        if (grabbedRigidbody == null) return;
        grabbedRigidbody.isKinematic = true;
        
        var rigidBodyTransform = grabbedRigidbody.transform;
        originalParent = rigidBodyTransform.parent;
        rigidBodyTransform.parent = transform;

        // Play the current player's grabbing sound
        AudioSource.PlayClipAtPoint(grabbingSound, transform.position);
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

    public void Initialize(AudioClip GrabSound, Sprite headSprite)
    {
        spriteShapeController.spline.SetPosition(1, transform.localPosition);
        spriteShapeController.spline.SetPosition(0, headOrigin.localPosition);
        grabbingSound = GrabSound;
        this.headSprite = headSprite;
        headVisuals.sprite = headSprite;
    }
}