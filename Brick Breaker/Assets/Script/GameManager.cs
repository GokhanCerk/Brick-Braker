using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int lives;
    public int scores;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject loadScreenPanel;
    public int numberOfBricks;
    public Transform[] levels;
    public int currentLevelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + scores;
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
    }

  /// <summary>
  /// Update Score
  /// </summary>
  /// <param name="changeInLives"></param>
    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;
    }


    /// <summary>
    /// Update Number Of Bricks
    /// </summary>
    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks <= 0) {

            if (currentLevelIndex >= levels.Length - 1)
            {
                GameOver();
            }
            else
            {
              
                loadScreenPanel.SetActive(true);
                loadScreenPanel.GetComponentInChildren<Text>().text = "Level " + (currentLevelIndex + 2);
                Invoke("LoadLevel",3f);
            }

            
        }
    }

    void LoadLevel()
    {
        currentLevelIndex++;
        loadScreenPanel.SetActive(false);
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
        gameOver = false;
    }


    /// <summary>
    /// 
    /// </summary>
    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    /// <summary>
    /// Loading Main Scene
    /// </summary>
    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }

    /// <summary>
    /// Quit Game
    /// </summary>
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    /// <summary>
    /// Update Score
    /// </summary>
    /// <param name="points"></param>
    public void UpdateScore(int points) {
        scores += points;
        scoreText.text = "Score: " + scores;
    }

}
