using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public enum ObstacleType
    {
        Vertical,
        Horizontal,
        DiagonalUp,
        DiagonalDown
    };

    public ObstacleType obstacleType;

    public float speed;

    public float upperBound = 1000f;
    public float lowerBound = -1000f;
    public float leftBound = -1000f;
    public float rightBound = 1000f;

    public bool movingUp = false;
    public bool movingDown = false;
    public bool movingLeft = false;
    public bool movingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        if (obstacleType == ObstacleType.Vertical)
        {
            movingUp = true;
            movingDown = false;
        }
        else if (obstacleType == ObstacleType.Horizontal)
        {
            movingRight = true;
            movingLeft = false;
        }
        else if (obstacleType== ObstacleType.DiagonalUp)
        {
            movingRight = true;
            movingUp = true;
        }
        else if (obstacleType == ObstacleType.DiagonalDown)
        {
            movingRight= true;
            movingDown= true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= upperBound)
        {
            if (obstacleType == ObstacleType.Vertical)
            {
                movingUp = false;
                movingDown = true;
            }
            else if (obstacleType == ObstacleType.DiagonalUp)
            {
                movingRight = false;
                movingUp = false;
                movingDown = true;
                movingLeft = true;
            }
            else if (obstacleType == ObstacleType.DiagonalDown)
            {
                movingUp = false;
                movingLeft = false;
                movingDown = true;
                movingRight = true;
            }
        }
        else if (transform.position.y <= lowerBound)
        {
            if (obstacleType == ObstacleType.Vertical)
            {
                movingUp = true;
                movingDown = false;
            }
            else if (obstacleType == ObstacleType.DiagonalUp)
            {
                movingRight = true;
                movingUp = true;
                movingDown = false;
                movingLeft = false;
            }
            else if (obstacleType == ObstacleType.DiagonalDown)
            {
                movingUp = true;
                movingLeft = true;
                movingDown = false;
                movingRight = false;
            }
        }
        else if (transform.position.x >= rightBound)
        {
            movingRight = false;
            movingLeft = true;
        }
        else if (transform.position.x <= leftBound)
        {
            movingLeft = false;
            movingRight = true;
        }

        if (movingUp)
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }
        if (movingDown)
        {
            transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
        }
        if (movingLeft)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        }
        if (movingRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }
}
