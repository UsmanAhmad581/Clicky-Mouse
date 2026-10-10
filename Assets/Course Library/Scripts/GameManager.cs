using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{   
    public List<GameObject> targets;
    private float spawnRate = 1.5f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI VolumeText;
    public int lives;
    public float volume = 1.0f;
    

    public bool isGameActive;
    public GameObject titleScreen;

    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        LivesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
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
    public void GameOver()
    {   if(lives <= 0)
        {
            gameOverText.gameObject.SetActive(true);
            isGameActive = false;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
}
