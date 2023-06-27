using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] GameObject umbrella;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Distance: " + Vector2.Distance(umbrella.transform.position, transform.position));

        /*if (Vector2.Distance(umbrella.transform.position, transform.position) > 10f)
        {
            ObstacleRearrange();
        }*/
        if (transform.position.y > (umbrella.transform.position.y + 1.7f))
        {
            ObstacleRearrange();
        }
    }

    private void ObstacleRearrange()
    {
        transform.position = new Vector3(0, umbrella.transform.position.y - 9.75f, 0);
    }
}
