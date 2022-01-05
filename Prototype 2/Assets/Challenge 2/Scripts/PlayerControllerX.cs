using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Monitor.TryEnter(MyLocks.mut))
            {
                if(MyLocks.canSpawn == true)
                {
                    Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                    MyLocks.canSpawn = false;
                }
                MyLocks.mut.ReleaseMutex();
            }
        }
    }
}
