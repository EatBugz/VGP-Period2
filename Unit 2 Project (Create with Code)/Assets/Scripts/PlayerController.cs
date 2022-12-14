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
        
        // move player
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed * hI);

        // keep player from moving past the boundry
        if (hI > 0 && transform.position.x > boundry) { 
            transform.position = new Vector3(boundry, transform.position.y, transform.position.z); 
        }
        else if (hI < 0 && transform.position.x < -boundry) { 
            transform.position = new Vector3(-boundry, transform.position.y, transform.position.z); 
        }
    }
}