using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement vars
    public float speed = 20f;
    public float turnSpeed = 45f;
    private float hI;
    private float vI;

    // move thing forward
    void Update()
    {
        hI = Input.GetAxisRaw("Horizontal");
        vI = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * vI);
        transform.Rotate(Vector3.up, turnSpeed * hI * Time.deltaTime);
    }
}
