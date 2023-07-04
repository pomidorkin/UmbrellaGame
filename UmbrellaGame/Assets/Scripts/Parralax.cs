using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    private float height, startPos, zPos;
    [SerializeField] private GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startPos = transform.position.y;
        zPos = transform.position.z;
        height = 10f;
    }

    private void FixedUpdate()
    {
        float dist = -(cam.transform.position.y * parallaxEffect);
        transform.position = new Vector3(transform.position.x, startPos + dist, zPos);

        if ((cam.transform.position.y - transform.position.y) >= 10f)
        {
            transform.position = new Vector3(transform.position.x, cam.transform.position.y, zPos);
            startPos += height;
        }
        else if ((cam.transform.position.y - transform.position.y) <= -10f)
        {
            transform.position = new Vector3(transform.position.x, cam.transform.position.y, zPos);
            startPos -= height;
        }
    }
}
