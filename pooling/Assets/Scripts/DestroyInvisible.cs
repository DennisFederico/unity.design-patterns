using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInvisible : MonoBehaviour {
    void OnBecameInvisible() {
        Pool.singleton.PutBack(gameObject);
        //Destroy(this.gameObject);
    }
}
