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
        // Bug with Parralax effect value
        float temp = (cam.transform.position.y * (1 - parallaxEffect));
        float dist = -(cam.transform.position.y * parallaxEffect);
        transform.position = new Vector2(transform.position.x, startPos + dist);

        if (temp > ((startPos + height) / 2))
        {
            startPos += height;
        }
        else if (temp < ((startPos - height) / 2))
        {
            startPos -= height;
        }

        Debug.Log("temp: " + temp + "  (startPos - height) / 2: " + ((startPos - height) / 2));
    }
}
