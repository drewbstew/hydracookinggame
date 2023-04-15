using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private HydraHead hydraHead;
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
        if (HasReachedLimit())
        {
            Debug.Log("HasReachedLimit");
            hydraHead.MoveHead(hydraHead.CurrentVelocity * -5);
        }
        
        var inputValue = controls.Gameplay.Move.ReadValue<Vector2>();
        hydraHead.MoveHead(inputValue * (Time.deltaTime * movementSpeed));
        
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