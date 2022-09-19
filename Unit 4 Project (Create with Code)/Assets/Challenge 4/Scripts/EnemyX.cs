using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private SpawnManagerX sMX;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        sMX = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
        playerGoal = GameObject.Find("Player Goal");

        // increase enemy speed by wave
        speed += sMX.waveCount*1;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
            sMX.enemyCount--;
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
            sMX.enemyCount--;
        }

    }

}
