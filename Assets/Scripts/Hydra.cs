using UnityEngine;
using UnityEngine.InputSystem;

public class Hydra : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private Transform[] playerSpawnPositions;
    [SerializeField] AudioClip[] grabbingSound;

    private int playerNumber;
    
    private void Start()
    {
        playerInputManager.onPlayerJoined += OnPlayerJoined;
    }

    private void OnPlayerJoined(PlayerInput input)
    {
        var targetSpawnPosition = playerSpawnPositions[playerNumber];
        var newPlayer = input.GetComponent<PlayerHead>();

        newPlayer.Spawn(targetSpawnPosition, grabbingSound[playerNumber]);
        playerNumber++;
    }
}
