using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball_Controller : MonoBehaviour
{

    public float speed = 10.0f;
    
    private Rigidbody rb;

    private bool isLaunched = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isLaunched && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(Random.Range(-1f, 1f), 1.0f).normalized * speed;
            isLaunched = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            Game_Manager.Instance.BrickDestroyed();
            ScoreManager.instance.AddScore(10);
            Destroy(other.gameObject);
        }else if (other.gameObject.CompareTag("GameOverZone"))
        {
            Game_Manager.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}
