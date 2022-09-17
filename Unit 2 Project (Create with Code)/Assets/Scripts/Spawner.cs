using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] animals;

    // spawn range of the animals
    [Header("Spawn Range")]
    public float spawnRangeX = 20f;
    public float spawnRangeZ = 20f;

    // timer for spawning animals
    [Header("Spawn Timer")]
    public float startDelay = 2f;
    public float spawnInterval = 1.5f;

    // at the start of the game, start spawning animals
    void Start() {
        InvokeRepeating("createAnimal", startDelay, spawnInterval);
    }

    // method that spawns a random animal
    public void createAnimal() {
        int index = Random.Range(0, animals.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX+1), 0, spawnRangeZ);
        Instantiate(animals[index], spawnPos, animals[index].transform.rotation);
    }
}
