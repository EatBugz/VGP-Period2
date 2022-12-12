using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public Rigidbody rb;
    public float jumpForce = 5f;
    public bool isGrounded = true;
    public bool gameOver = false;
    private Animator anim;
    
    [Header("Particles")]
    public ParticleSystem explosion;
    public ParticleSystem dirt;

    [Header("SFX")]
    public AudioSource aS;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            aS.PlayOneShot(jumpSound, 1.0f);
            anim.SetTrigger("Jump_trig");
            dirt.Stop();
        }
    }

    // if player touches the ground, allow them to jump
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ground") {
            isGrounded = true;
            aS.PlayOneShot(crashSound, 1.0f);
            dirt.Play();
        }
        else if (col.gameObject.tag == "Obstacle") {
            gameOver = true;
            explosion.Play();
            dirt.Stop();
            Debug.Log("Game Over!");
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
        }
    }
}
