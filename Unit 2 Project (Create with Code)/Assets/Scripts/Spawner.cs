using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] animals;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createAnimal() {
        int index = Random.Range(0, animals.Length);
        Instantiate(animals[index], new Vector3(0, 0, 20), animals[index].transform.rotation);
    }
}
