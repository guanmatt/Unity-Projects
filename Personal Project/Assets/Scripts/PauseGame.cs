using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private static bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool isPaused()
    {
        return paused;
    }

    public static void togglePaused()
    {
        paused = !paused;
    }

    private static void OnGUI()
    {
        if (paused)
        {
            GUILayout.Label("Game is paused!");
            GUILayout.Box("hello");
        }
    }
}
