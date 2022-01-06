using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {


        if(!PauseGame.isPaused())
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }
        else
        {

        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            if(PauseGame.isPaused())
            {
                //isPaused = false;
                //resume
            }
            else
            {
                //isPaused = true;
                //pause
            }
            Cursor.visible = !Cursor.visible;
            PauseGame.togglePaused();
        }
    }
}

