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
    private float maxHoleSize = 3.3f;

    // Obstacle Types
    [SerializeField] GameObject regularObstacle;
    [SerializeField] GameObject movingObstacle;
    [SerializeField] GameObject closingObstacle;

    // PowerUp variables
    [SerializeField] PowerUpUnit powerUpUnit;
    [SerializeField] PowerUpController powerUpController;
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
        gameObject.transform.localPosition = initialObstaclePos;
        leftPlatform.transform.localPosition = initialLeftPlatforPos;
        rightPlatform.transform.localPosition = initialRightPlatforPos;
        obstacleOffset = 1.4f;
        lastScore = 0;
    }

    private void Start()
    {
        initialObstaclePos = gameObject.transform.localPosition;
        initialLeftPlatforPos = leftPlatform.transform.localPosition;
        initialRightPlatforPos = rightPlatform.transform.localPosition;
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
        // Obstacle position change & hole decreasing logic
        float rnd = UnityEngine.Random.Range(-obstacleOffset + 0.7f, obstacleOffset - 0.7f);
        transform.position = new Vector3(rnd, transform.localPosition.y - 20f, 0);
        scoreCounter.AddScore();
        if ((lastScore + 5) < scoreCounter.score) // Every 5 platforms the hole size decreases
        {
            lastScore = scoreCounter.score;
            Debug.Log("rightPlatform.transform.position.x: " + rightPlatform.transform.localPosition.x + ", maxHoleSize: " + maxHoleSize);
            if ((rightPlatform.transform.localPosition.x - sidesOffset) > maxHoleSize)
            {
                rightPlatform.transform.localPosition = new Vector2(rightPlatform.transform.localPosition.x - sidesOffset, rightPlatform.transform.localPosition.y);
                leftPlatform.transform.localPosition = new Vector2(leftPlatform.transform.localPosition.x + sidesOffset, leftPlatform.transform.localPosition.y);
                obstacleOffset += sidesOffset;
            }
            
        }
        if (!regularObstacle.gameObject.activeInHierarchy)
        {
            regularObstacle.SetActive(true);
        }

        // Obstacle type choosing logic

        if (scoreCounter.score > 15) // Balance Value
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

        // Power-Up spawning & despawning logic
        Debug.Log("powerUpController.powerupIsActive: " + powerUpController.powerupIsActive + ", powerUpController.powerUpIsSpawned: " + powerUpController.powerUpIsSpawned);

        if (powerUpUnit.gameObject.activeInHierarchy)
        {
            powerUpUnit.DisablePowerUp();
            powerUpUnit.gameObject.SetActive(false);
            powerUpController.powerUpIsSpawned = false;
        }
        if (!powerUpController.powerupIsActive && !powerUpController.powerUpIsSpawned)
        {
            if (scoreCounter.score > 0 && !powerUpController.powerUpIsSpawned && !powerUpController.powerUpIsSpawned) // TODO: Set a score value after which powerups will spawn
            {
                int rnd2 = UnityEngine.Random.Range(1, 21); // TODO: PowerUp spawn chance
                if (rnd2 == 1)
                {
                    powerUpUnit.gameObject.SetActive(true);
                }
            }
        }
    }
}
