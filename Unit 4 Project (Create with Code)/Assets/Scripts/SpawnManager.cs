using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] enemyPrefabs;
    public GameObject[] powerups;

    [Header("Wave stats")]
    public float spawnRange = 9f;
    public int enemyCount;
    public int wave = 1;

    // Start is called before the first frame update
    void Start()
    {
        spawnPowerup();
        spawnEnemyWave(wave);
    }

    // if all enemies are gone, make a new wave
    void Update() {
        if (enemyCount <= 0) {
            wave++;
            spawnPowerup();
            spawnEnemyWave(wave);
        }
    }

    // method that generates a random spawn point
    public Vector3 randomSpawn() {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnX, 0, spawnZ);
    }

    // method that creates a powerup
    public void spawnPowerup() {
        int ran = Random.Range(0, powerups.Length);
        Instantiate(powerups[ran], randomSpawn(), powerups[ran].transform.rotation);
    }

    // method that spawns a wave of enemies
    public void spawnEnemyWave(int num) {
        for (int i = 0; i < num; i++) {
            int ran = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[ran], randomSpawn(), enemyPrefabs[ran].transform.rotation);
            enemyCount++;
        }
    }
}
