using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] GameObject umbrella;
    [SerializeField] ScoreCounter scoreCounter;
    [SerializeField] GameObject leftPlatform;
    [SerializeField] GameObject rightPlatform;
    private float obstacleOffset = 1.4f;
    private float sidesOffset = 0.2f;
    private int lastScore = 0;
    // Initil Data for Resetting
    [SerializeField] GameResetter gameResetter;
    private Vector2 initialObstaclePos;
    private Vector2 initialLeftPlatforPos;
    private Vector2 initialRightPlatforPos;

    // Obstacle Types
    [SerializeField] GameObject regularObstacle;
    [SerializeField] GameObject movingObstacle;
    [SerializeField] GameObject closingObstacle;

    // PowerUp variables
    [SerializeField] GameObject powerUpUnit;
    private void OnEnable()
    {
        gameResetter.OnGameReset += ResetObstacle;
    }

    private void OnDisable()
    {
        gameResetter.OnGameReset -= ResetObstacle;
    }

    private void ResetObstacle()
    {
        gameObject.transform.position = initialObstaclePos;
        leftPlatform.transform.position = initialLeftPlatforPos;
        rightPlatform.transform.position = initialRightPlatforPos;
        obstacleOffset = 1.4f;
        lastScore = 0;
    }

    private void Start()
    {
        initialObstaclePos = gameObject.transform.position;
        initialLeftPlatforPos = leftPlatform.transform.position;
        initialRightPlatforPos = rightPlatform.transform.position;
    }
    void Update()
    {
        if (transform.position.y > (umbrella.transform.position.y + 1.7f))
        {
            ObstacleRearrange();
        }
    }

    private void ObstacleRearrange()
    {
        float rnd = UnityEngine.Random.Range(-obstacleOffset, obstacleOffset);
        transform.position = new Vector3(rnd, transform.position.y - 12f, 0);
        if ((lastScore + 20) < scoreCounter.score)
        {
            lastScore = scoreCounter.score;
            rightPlatform.transform.position = new Vector2(rightPlatform.transform.position.x - sidesOffset, rightPlatform.transform.position.y);
            leftPlatform.transform.position = new Vector2(leftPlatform.transform.position.x + sidesOffset, leftPlatform.transform.position.y);
            obstacleOffset += sidesOffset;
            Debug.Log("obstacleOffset: " + obstacleOffset);
        }

        if (scoreCounter.score > 60) // Balance Value
        {
            int rand = UnityEngine.Random.Range(1, 11);
            if (rand == 1)
            {
                transform.position = new Vector2(0, transform.position.y);
                regularObstacle.SetActive(false);
                closingObstacle.SetActive(false);
                movingObstacle.SetActive(true);
            }
            else if (rand == 2)
            {
                transform.position = new Vector2(0, transform.position.y);
                regularObstacle.SetActive(false);
                closingObstacle.SetActive(true);
                movingObstacle.SetActive(false);
            }
            else
            {
                regularObstacle.SetActive(true);
                closingObstacle.SetActive(false);
                movingObstacle.SetActive(false);
            }
        }

        if (scoreCounter.score > 0) // TODO: Set a score value after which powerups will spawn
        {
            int rnd2 = UnityEngine.Random.Range(1,21); // TODO: PowerUp spawn chance
            if (rnd2 == 1)
            {
                powerUpUnit.SetActive(true);
            }
        }
    }
}
