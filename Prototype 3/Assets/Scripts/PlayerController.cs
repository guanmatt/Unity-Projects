using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    private bool isJumpStateReady = false;
    private float heldForce = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
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
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
