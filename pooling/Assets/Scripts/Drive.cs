using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour {
    public float speed = 10.0f;

    public GameObject bullet;
    public Slider healthBar;
    public GameObject explosion;

    void Update() {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }

        //Get Canvas Coords into World Coords
        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthBar.transform.position = screenPos + (Vector3.down * 130);
    }

    void Shoot() {
        GameObject bullet = Pool.singleton.Get("Bullet");
        if (bullet != null) {
            bullet.transform.position = this.transform.position;
            bullet.SetActive(true);
        }
        //Instantiate(bullet, this.transform.position, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Asteroid")) {
            ReduceHealth();
        }
        if (healthBar.value <= 0) {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(healthBar, 0.5f);
            Destroy(gameObject, 0.5f);
        }
    }

    public void ReduceHealth() {
        healthBar.value -= 5;
    }
}