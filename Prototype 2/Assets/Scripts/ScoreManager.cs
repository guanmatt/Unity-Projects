using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private string scoreText;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddPoints(int amount)
    {
        score += amount;
        scoreText = "Score: " + score;
        Debug.Log("Animal fed! +1");
    }
    public string GetScore()
    {
        return scoreText;//scoreText.text;
    }
}
