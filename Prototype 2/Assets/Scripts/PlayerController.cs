using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    private float xRange = 20;
    private float timer = 0.0f;
    public float timerCD = 2.0f;
    private float dashSpeed = 1.0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Dash"))
        {
            dashSpeed = 3.0f;
        }
        else
        {
            dashSpeed = 1.0f;
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed * dashSpeed);

        timer -= timer <= 0 ? 0 : Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && timer <= 0.0f) {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            timer = timerCD;
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width/10.0f, Screen.height - Screen.height/10, 60.0f, 30.0f), timer <= 0.0f ? "READY" : timer.ToString("F2"));
    }
}
