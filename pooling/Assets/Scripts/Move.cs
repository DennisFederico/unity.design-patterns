using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    
    public Vector3 velocity;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Asteroid")) {
            Pool.singleton.PutBack(other.gameObject);
            Pool.singleton.PutBack(gameObject);
            // Destroy(other.gameObject);
            // Destroy(gameObject);
        }
    }

    void Update() {
        transform.Translate(velocity);
    }
}
