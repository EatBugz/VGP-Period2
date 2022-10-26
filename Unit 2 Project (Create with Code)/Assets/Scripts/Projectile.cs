using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 15f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // destroy the projectile and animal if they collide
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Animal") {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
