using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public BoxCollider2D collider;

    private void Start() {
        collider.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(other.gameObject);
    }
}
