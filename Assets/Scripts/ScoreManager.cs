using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    
    public TextMeshProUGUI scoreText;

    private int score = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int points)
    {
        Debug.Log("Add Score");
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }
}
