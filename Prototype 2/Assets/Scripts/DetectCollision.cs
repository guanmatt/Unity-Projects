using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameObject scoreManagerObject;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("ScoreManager") == null)
        {
            Debug.LogError("couldnt find scoremanager");
        }
        scoreManagerObject = GameObject.Find("ScoreManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
        Destroy(gameObject);
        Destroy(other.gameObject);
        if (scoreManager != null) scoreManager.AddPoints(1);
    }
}
