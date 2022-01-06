using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject target;
    
    Vector3 offset;// = new Vector3(-2, 1, -1);
    
    public float sensitivity = 1.0f;
    public float rotateSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.transform.position + new Vector3( 1, 1.5f, -2);
        /*offset.x = target.transform.position.x + 1;// - transform.position.x;
        offset.y = target.transform.position.y + 1;// - transform.position.y;
        offset.z = target.transform.position.z - 2;// - transform.position.z;*/
        offset = target.transform.position - transform.position;



    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PauseGame.isPaused()) return;
        float rotateVertical = Input.GetAxis("Mouse Y");

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);
        
        transform.LookAt(target.transform.position + target.transform.forward * 5 );

    }
}
