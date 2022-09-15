using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    public GameObject food;
    public float speed = 15f;

    // Update is called once per frame
    void Update()
    {
        // get mouse input
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            // get position of the mouse
            Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // get direction of the mouse based on the player's position
            Vector2 direction = cursorInWorldPos - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            direction.Normalize();

            // create the projectile and update its transform
            GameObject foo = Instantiate(food);
            foo.transform.position = new Vector3(transform.position.x, transform.position.y+2, transform.position.z);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);
            foo.transform.rotation = targetRotation;
        }
    }
}
