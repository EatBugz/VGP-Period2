using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private float hI;
    private float vI;

    // Update is called once per frame
    void Update()
    {
        hI = Input.GetAxisRaw("Horizontal");
        vI = Input.GetAxisRaw("Vertical");
    }
}
