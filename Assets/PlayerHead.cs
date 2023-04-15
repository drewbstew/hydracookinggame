using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    [SerializeField] private HydraHead head;

    public void Spawn(Transform targetSpawnPosition, AudioClip grab)
    {
        transform.parent = targetSpawnPosition;
        transform.position = targetSpawnPosition.position;
        head.Initialize(grab);
    }
}
