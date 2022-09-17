using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // if animal collides with the player
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
    }
}
