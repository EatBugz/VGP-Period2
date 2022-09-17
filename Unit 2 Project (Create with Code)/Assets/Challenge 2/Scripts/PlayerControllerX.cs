using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    public bool canAttack = true;
    public float attackDelay = 0.5f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        // stop the player from spamming space
        if (!canAttack) {
            timer += Time.deltaTime;
            if (timer >= attackDelay) {
                canAttack = true;
                timer = 0f;
            }
        }

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            canAttack = false;
        }
    }
}
