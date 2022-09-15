using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float boundry = 10;
    public float speed = 10f;
    private float hI;
    private float vI;

    // Update is called once per frame
    void Update()
    {
        // get input
        hI = Input.GetAxisRaw("Horizontal");
        vI = Input.GetAxisRaw("Vertical");
        
        // move player
        transform.Translate(Vector3.right * Time.deltaTime * speed * hI);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vI);

        // keep player from moving past the boundry
        if (hI > 0 && transform.position.x > boundry) { 
            transform.position = new Vector3(boundry, transform.position.y, transform.position.z); 
        }
        else if (hI < 0 && transform.position.x < -boundry) { 
            transform.position = new Vector3(-boundry, transform.position.y, transform.position.z); 
        }
        if (vI > 0 && transform.position.z > boundry) { 
            transform.position = new Vector3(transform.position.x, transform.position.y, boundry); 
        }
        else if (vI < 0 && transform.position.z < -boundry/10) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -boundry/10);
        }
    }
}