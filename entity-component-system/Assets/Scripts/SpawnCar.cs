using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour {
    public GameObject car;
    public GameObject sceneCamera;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 pos = new Vector3(12, 5, 12);
            GameObject c = GameObject.Instantiate(car, pos, Quaternion.identity);
            sceneCamera.GetComponent<SmoothFollow>().target = c.transform;
        }
    }
}
