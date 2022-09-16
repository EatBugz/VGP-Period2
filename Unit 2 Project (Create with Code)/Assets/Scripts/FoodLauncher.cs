using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    public GameObject food;

    // Update is called once per frame
    void Update()
    {
        // get mouse input
        if (Input.GetKeyDown(KeyCode.Mouse0)) {

            // create the projectile and update its transform
            GameObject foo = Instantiate(food, new Vector3(transform.position.x, transform.position.y+2, transform.position.z), Quaternion.identity);
        }
    }
}
