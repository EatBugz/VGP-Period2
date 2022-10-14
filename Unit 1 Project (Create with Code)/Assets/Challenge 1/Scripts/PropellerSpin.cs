using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    // propeller rotation speed
    public float rotationSpeed;

    // rotate propeller
    void Update()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
    }
}
