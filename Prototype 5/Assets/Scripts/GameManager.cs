using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOverBox;
    public GameObject titleScreen;
    public Button restartButton;
    public bool isGameActive;
    
    private float spawnRate = 1.0f;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    // Update is called once per frame

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        //Debug.Log(gameOverBox.name.ToString());
        gameOverBox.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        
    }
}
