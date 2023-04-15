using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public BoxCollider2D coll;

    private void Start() {
        coll.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(other.gameObject);
    }
}
