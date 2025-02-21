using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Random_Level_Generator : MonoBehaviour
{
    public GameObject brickPrefab;

    public int rows = 4;
    public int columns = 8;

    public float brickWidth = 1f;

    public float brickHeight = 0.4f;

    public float spacing = 0.2f;

    public float brickProbability = 0.7f;

    public int numberOfBricks = 0;
    
    public Color[] randomColors;

    private void Start()
    {
        
    }

    public void GenerateRandomLevel()
    {
        float startX = -(columns / 2f) * (brickWidth + spacing) + (brickWidth / 2f);
        float startY = 4f;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (Random.value < brickProbability)
                {
                    Vector2 position = new Vector2(
                        startX + col * (brickWidth + spacing),
                        startY - row * (brickHeight + spacing));
                    
                    GameObject _brick = Instantiate(brickPrefab, position, Quaternion.identity, transform);
                    
                    _brick.GetComponent<SpriteRenderer>().color = randomColors[Random.Range(0, randomColors.Length)];
                    _brick.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    numberOfBricks++;
                }
                
            }
        }
    }
}
