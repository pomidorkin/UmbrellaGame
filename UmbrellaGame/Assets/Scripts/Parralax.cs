using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    private float height, startPos;
    [SerializeField] private GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startPos = transform.position.y;
        height = 10f;
    }

    private void FixedUpdate()
    {
        float dist = -(cam.transform.position.y * parallaxEffect);
        transform.position = new Vector2(transform.position.x, startPos + dist);

        if ((cam.transform.position.y - transform.position.y) >= 10f)
        {
            transform.position = new Vector2(transform.position.x, cam.transform.position.y);
            startPos += height;
        }
        else if ((cam.transform.position.y - transform.position.y) <= -10f)
        {
            transform.position = new Vector2(transform.position.x, cam.transform.position.y);
            startPos -= height;
        }
    }
}
