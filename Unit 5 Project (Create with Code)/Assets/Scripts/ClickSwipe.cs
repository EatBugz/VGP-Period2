using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickSwipe : MonoBehaviour
{
    // vars
    private GameManager gM;
    private Vector3 mousePos;
    private TrailRenderer trail;
    private BoxCollider col;
    public bool swiping = false;

    // get stuff
    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;
        gM = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // trail rendering plus switching collision on and off
    void Update()
    {
        if (gM.gaming) {
            if (Input.GetMouseButtonDown(0)) {
                swiping = true;
                updateComponents();
            }
            else if (Input.GetMouseButtonUp(0)) {
                swiping = false;
                updateComponents();
            }
            if (swiping) updateMousePos();
        }
    }

    // collision with targets
    public void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.tag == "Bad" || coll.gameObject.tag == "Good") {
            coll.gameObject.GetComponent<Target>().destroyObject(true);
        }
    }

    // updates the mouse position
    public void updateMousePos() {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        transform.position = mousePos;
    }

    // updates components based on swiping enable
    public void updateComponents() {
        trail.enabled = swiping;
        col.enabled = swiping;
    }
}
