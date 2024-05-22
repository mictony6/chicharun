using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector2 direction;
    public Vector2 lastDirection;
    private int speed = 200;
    public float speedModifier = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if (direction != Vector2.zero)
        {
            lastDirection = direction;
        }
    }

    private void GetInput()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        direction.Normalize();
    }

    public float GetSpeed()
    {
        return speed * speedModifier;
    }


}
