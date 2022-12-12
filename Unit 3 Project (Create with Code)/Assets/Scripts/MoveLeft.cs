using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -15f;
    private PlayerController pC;

    void Start() {
        pC = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pC.gameOver && pC.gameStart) { transform.Translate(Vector3.left * Time.deltaTime * speed); }

        if (transform.position.x < leftBound && gameObject.tag == "Obstacle") { Destroy(gameObject); }
    }
}
