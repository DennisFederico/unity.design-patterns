using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    public GameObject asteroidPrefab;

    // Update is called once per frame
    void Update() {
        if (Random.Range(0, 100) < 1) {
            GameObject asteroid = Pool.singleton.Get("Asteroid");
            if (asteroid != null) {
                Vector3 pos = this.transform.position + new Vector3(Random.Range(-10, 10), 0, 0);
                asteroid.transform.position = pos;
                asteroid.SetActive(true);
            }
            // Instantiate(asteroidPrefab, this.transform.position + new Vector3(Random.Range(-10, 10), 0, 0), Quaternion.identity);
        }
    }
}
