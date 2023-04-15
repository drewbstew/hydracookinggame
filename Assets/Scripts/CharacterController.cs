using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private HydraHead hydraHead;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementRadius;
    [SerializeField] private Transform neckOrigin;
    [SerializeField] private float radiusForce;
    [SerializeField] private float disabledTime;
    
    private Controls controls;
    private bool movementDisabled;

    private void Start()
    {
        controls = new Controls();
        controls.Enable();
        playerInput.user.AssociateActionsWithUser(controls);
    }

    private void Update()
    {
        if (HasReachedLimit())
        {
            movementDisabled = true;
            StartCoroutine(EnableMovement());
            hydraHead.MoveHead(hydraHead.CurrentVelocity * -radiusForce);
        }   

        if (controls.Gameplay.Grab.IsPressed())
        {
            hydraHead.Grab();
        } else if (controls.Gameplay.Grab.WasReleasedThisFrame())
        {
            hydraHead.Release();
        }

        if (!movementDisabled)
        {
            var inputValue = controls.Gameplay.Move.ReadValue<Vector2>();
            hydraHead.MoveHead(inputValue * (Time.deltaTime * movementSpeed));
        }
    }

    private IEnumerator EnableMovement()
    {
        yield return new WaitForSeconds(disabledTime);
        movementDisabled = false;
    }

    private bool HasReachedLimit()
    {
        return Vector2.Distance(neckOrigin.position, hydraHead.gameObject.transform.position) > movementRadius;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(neckOrigin.position, movementRadius);
        Gizmos.color = HasReachedLimit() ? Color.red : Color.yellow;
        Gizmos.DrawLine(neckOrigin.position, hydraHead.gameObject.transform.position);
    }
}