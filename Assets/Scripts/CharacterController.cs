using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class HydraHead : MonoBehaviour
{
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

public class CharacterController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementRadius;
    [SerializeField] private Transform neckOrigin;

    private Controls controls;

    private void Start()
    {
        controls = new Controls();
        controls.Enable();
        playerInput.user.AssociateActionsWithUser(controls);
    }

    private void Update()
    {
        if (controls.Gameplay.Move.triggered)
        {
            Debug.Log("Movement Triggered");
        }
        
        var inputValue = controls.Gameplay.Move.ReadValue<Vector2>();
        rigidbody.AddForce(inputValue * (Time.deltaTime * movementSpeed));
        // Control limits
        if (HasReachedLimit())
        {
            Debug.Log("HasReachedLimit");
            rigidbody.AddForce(rigidbody.velocity * -1);
        }
    }

    private bool HasReachedLimit()
    {
        return Vector2.Distance(neckOrigin.position, transform.position) > movementRadius;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(neckOrigin.position, movementRadius);
    }
}