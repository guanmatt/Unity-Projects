using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
public static class MyLocks
{
    public static Mutex mut = new Mutex();
    public static bool canSpawn = true;
}
public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -30;
    private float bottomLimit = -5;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            MyLocks.mut.WaitOne();
            Destroy(gameObject);
            MyLocks.canSpawn = true;
            MyLocks.mut.ReleaseMutex();
        } 
        // Destroy balls if y position is less than bottomLimit
        if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }

    }
}
