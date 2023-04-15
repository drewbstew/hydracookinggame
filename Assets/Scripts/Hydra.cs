using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hydra : MonoBehaviour
{
    [SerializeField] private HydraHead headPrefab;
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private Vector2[] playerSpawnPositions;


    private int playerNumber;
    private void Start()
    {
        playerInputManager.onPlayerJoined += OnPlayerJoined;
    }

    private void OnPlayerJoined(PlayerInput input)
    {
        var newHead = input.GetComponent<HydraHead>();
        var targetSpawnPosition = Vector2.zero;
        if (playerSpawnPositions.Length > playerNumber)
        {
            targetSpawnPosition = playerSpawnPositions[playerNumber];
        }

        newHead.transform.parent = transform;
        newHead.Spawn(targetSpawnPosition);
    }
}
