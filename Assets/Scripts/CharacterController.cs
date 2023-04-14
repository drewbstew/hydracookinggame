using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody2D rigidbody;
    
    private Controls controls;
    private void Start()
    {
        controls = new Controls();
        controls.Enable();
        playerInput.user.AssociateActionsWithUser(controls);
    }

    // Update is called once per frame
    private void Update()
    {
        var inputValue = controls.Gameplay.Move.ReadValue<Vector2>();
        rigidbody.AddForce(inputValue);    
    }
}
