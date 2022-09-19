using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRange = 9f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, randomSpawn(), enemy.transform.rotation);
    }

    // method that generates a random spawn point
    public Vector3 randomSpawn() {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnX, 0, spawnZ);
    }
}
