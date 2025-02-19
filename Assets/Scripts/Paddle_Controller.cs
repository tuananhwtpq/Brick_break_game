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
        Vector3 movement = new Vector3(input, 0, 0) * (speed * Time.deltaTime);
        transform.Translate(movement);
        
        Vector3 posClamp = transform.position;
        posClamp.x = Mathf.Clamp(posClamp.x, -9.0f, 9.0f);
        transform.position = posClamp;

    }
}
