using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gM;

    public int pointValue;
    public GameObject explosionParticles;

    [Header("Spawn Stats")]
    public float minSpeed = 12f;
    public float maxSpeed = 16f;
    public float maxTorque = 10f;
    public float xRange = 4f;
    public float ySpawnPos = -6f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gM = GameObject.Find("Game Manager").GetComponent<GameManager>();

        rb.AddForce(randomForce(), ForceMode.Impulse);
        rb.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);
        transform.position = randomSpawn();
    }

    // returns a random force
    public Vector3 randomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    // returns random torque
    public float randomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }
    // returns a random spawn pos
    public Vector3 randomSpawn() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // collision
    public void OnMouseDown() {
        if (gM.gaming) {
            destroyObject();
        }
    }

    // destroys itself
    public void destroyObject() {
        if (gameObject.tag == "Bad") gM.updateLives(-1);

        Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
        Destroy(gameObject);
        gM.updateScore(pointValue);
    }
}
