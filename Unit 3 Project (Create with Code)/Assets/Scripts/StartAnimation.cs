using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public float animationSpeed = 0.1f;
    private PlayerController pC;
    private bool playedAnimation = false;

    // Start is called before the first frame update
    void Start()
    {
        pC = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playedAnimation) {
            playedAnimation = true;
            StartCoroutine(startingAnimation());
        }
    }

    // animation
    public IEnumerator startingAnimation() {
        while (gameObject.transform.position.x < 0) {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x+animationSpeed, gameObject.transform.position.y);
            yield return null;
        }
        pC.gameStart = true;
    }
}
