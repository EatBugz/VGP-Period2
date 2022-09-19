using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    private GameObject player;
    private SpawnManager sM;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        sM = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDirection = (player.transform.position-transform.position).normalized;
        rb.AddForce(playerDirection * speed);

        // if enemy falls off, destroy it
        if (transform.position.y <= -10) { 
            Destroy(gameObject);
            sM.enemyCount--; 
        }
    }
}
