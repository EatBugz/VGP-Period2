using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // obstacle vars
    public GameObject obstacle;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    [Header("Spawn Timer")]
    public float startDelay = 2f;
    public float repeatRate = 2f;

    // player controller
    private PlayerController pC;

    // Start is called before the first frame update
    void Start()
    {
        pC = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("createObstacle", startDelay, repeatRate);
    }

    // method that creates an obstacle
    public void createObstacle() {
        if (!pC.gameOver) { Instantiate(obstacle, spawnPos, obstacle.transform.rotation); }
    }
}
