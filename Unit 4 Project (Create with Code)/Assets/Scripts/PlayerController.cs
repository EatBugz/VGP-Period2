using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [Header("Movement vars")]
    public Rigidbody rb;
    public float speed = 5f;
    private float vI;
    private GameObject focalPoint;

    [Header("Powerup vars")]
    public bool hasPower = false;
    public float powerupStrength = 15f;
    public float powerupLength = 7f;
    public GameObject powerupIndicator;

    [Header("Rocket Vars")]
    public PowerType currentPowerup = PowerType.Null;
    public GameObject rocketPrefab;
    private Coroutine powerUpCountdown;

    [Header("Smash Vars")]
    public float hangTime;
    public float smashSpeed;
    public float explosionForce;
    public float explosionRadius;
    private bool smashing = false;
    private float floorY;

    void Start() {
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        powerupIndicator.transform.position = new Vector3(transform.position.x, transform.position.y-0.4f, transform.position.z);
        vI = Input.GetAxisRaw("Vertical");
        rb.AddForce(focalPoint.transform.forward * speed * vI);

        // rocket powerup
        if (Input.GetKeyDown(KeyCode.F) && currentPowerup == PowerType.Rockets) LaunchRockets();

        // smash powerup
        if (Input.GetKeyDown(KeyCode.Space) && currentPowerup == PowerType.Smash) {
            smashing = true;
            StartCoroutine(Smash());
        }
    }

    /// collision
    // collision with powerup
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Powerup") {
            Destroy(col.gameObject);
            hasPower = true;
            currentPowerup = col.gameObject.GetComponent<PowerUp>().powerUp;
            powerupIndicator.SetActive(hasPower);

            if(powerUpCountdown != null) StartCoroutine(countdownPowerup());
            powerUpCountdown = StartCoroutine(countdownPowerup());
        }
    }
    // collision with enemy
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Enemy" && currentPowerup == PowerType.Pushback) {
            Rigidbody enemyRb = col.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (col.gameObject.transform.position - transform.position);

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    // launches rockets
    void LaunchRockets() {
        GameObject[] en = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in en) {
            GameObject foo = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);
            foo.GetComponent<RocketBehaviour>().Fire(enemy.transform);
        }
    }

    // smash
    public IEnumerator Smash() {
        GameObject[] en = GameObject.FindGameObjectsWithTag("Enemy");

        floorY = transform.position.y;

        float jumpTime = Time.time + hangTime;

        while (Time.time < jumpTime) {
            rb.velocity = new Vector2(rb.velocity.x, smashSpeed);
            yield return null;
        }

        while (transform.position.y > floorY) {
            rb.velocity = new Vector2(rb.velocity.x, -smashSpeed * 2);
            yield return null;
        }

        for (int i = 0; i < en.Length; i++) {
            if (en[i] != null) {
                en[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, 0f, ForceMode.Impulse);
            }
        }

        smashing = false;
    }

    // powerup countdown timer
    public IEnumerator countdownPowerup() {
        yield return new WaitForSeconds(powerupLength);
        hasPower = false;
        currentPowerup = PowerType.Null;
        powerupIndicator.SetActive(hasPower);
    }
}
