using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    private GameObject scoreManagerObject;


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("ScoreManager") == null)
        {
            Debug.LogError("couldnt find scoremanager");
        }
        scoreManagerObject = GameObject.Find("ScoreManager");

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            ScoreManager scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
            Destroy(gameObject);
            Time.timeScale = 0;
            Debug.Log("Game Over!");
            if (scoreManager != null)  Debug.Log(scoreManager.GetScore());
        }
    }
}
