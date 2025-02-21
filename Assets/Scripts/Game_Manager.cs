using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance;

    public GameObject ballPrefab;

    public Transform paddle;

    public Random_Level_Generator levelGenerator;

    private int remainBricks;

    public GameObject gameOverUI;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ResetBall();
        levelGenerator.GenerateRandomLevel();
        CountBrick();
    }

    void ResetBall()
    {
        Instantiate(ballPrefab, paddle.position + new Vector3(0, 1.0f, 0), Quaternion.identity);
        
    }

    void CountBrick()
    {
        remainBricks = levelGenerator.numberOfBricks;
    }

    public void BrickDestroyed()
    {
        remainBricks--;
        if (remainBricks <= 0)
        {
            LevelFinished();
        }
    }

    void LevelFinished()
    {
        Debug.Log("Level is finished");
        levelGenerator.GenerateRandomLevel();
        CountBrick();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }
    
}
