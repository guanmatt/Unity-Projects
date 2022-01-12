using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    private bool isJumpStateReady = false;
    private float heldForce = 1.0f;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        jump();
       
    }
    /////////////////////////////////////////////////////////////
    /// <summary>
    /// jump height is based on hold time,
    /// must press space again after landing to jump again
    /// </summary>
    private void jump() 
    {
        if (!isOnGround) return;
        if (gameOver) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumpStateReady = true;
        }

        if (Input.GetKey(KeyCode.Space) && isJumpStateReady && heldForce < 2.0f) //try to change force based on hold time
        {
            heldForce += Time.deltaTime;
        }
        else if (isJumpStateReady)
        {
            playerRb.AddForce(Vector3.up * jumpForce * heldForce, ForceMode.Impulse);
            isOnGround = false;
            heldForce = 1.0f;
            isJumpStateReady = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
