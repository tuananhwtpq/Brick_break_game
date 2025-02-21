using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Controller : MonoBehaviour
{
    public float speed = 10.0f;

    private void Update()
    {
        float input = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(input, 0f, 0f).normalized * (speed * Time.deltaTime);
        transform.Translate(movement);

        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -9f, 9f);
        transform.position = clampedPos;
    }
}
