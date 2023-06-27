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
        if ((lastScore + 100) < scoreCounter.score)
        {
            lastScore = scoreCounter.score;
            rightPlatform.transform.position = new Vector2(rightPlatform.transform.position.x - sidesOffset, rightPlatform.transform.position.y);
            leftPlatform.transform.position = new Vector2(leftPlatform.transform.position.x + sidesOffset, leftPlatform.transform.position.y);
            obstacleOffset += sidesOffset;
            Debug.Log("obstacleOffset: " + obstacleOffset);
        }
    }
}
