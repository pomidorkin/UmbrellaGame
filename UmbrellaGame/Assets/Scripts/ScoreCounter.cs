using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] UmbrellaMovement umbrellaMovement;
    private Vector2 lastPosition;
    public int score = 0;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = umbrellaMovement.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0.2f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            if (umbrellaMovement.transform.position.y < (lastPosition.y - 10f))
            {
                lastPosition = umbrellaMovement.transform.position;
                score += 10;
                Debug.Log("Score: " + score);
            }
        }


    }
}
