using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float hI;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        hI = Input.GetAxisRaw("Horizontal");
        transform.Rotate(-Vector3.up, hI * speed * Time.deltaTime);
    }
}
