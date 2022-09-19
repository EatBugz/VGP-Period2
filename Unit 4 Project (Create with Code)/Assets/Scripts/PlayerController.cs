using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start() {
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        powerupIndicator.transform.position = new Vector3(transform.position.x, transform.position.y-0.4f, transform.position.z);
        vI = Input.GetAxisRaw("Vertical");
        rb.AddForce(focalPoint.transform.forward * speed * vI);
    }

    /// collision
    // collision with powerup
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Powerup") {
            Destroy(col.gameObject);
            hasPower = true;
            powerupIndicator.SetActive(hasPower);
            StartCoroutine(countdownPowerup());
        }
    }
    // collision with enemy
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Enemy") {
            Rigidbody enemyRb = col.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (col.gameObject.transform.position - transform.position);

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    // powerup countdown timer
    public IEnumerator countdownPowerup() {
        yield return new WaitForSeconds(powerupLength);
        hasPower = false;
        powerupIndicator.SetActive(hasPower);
    }
}
