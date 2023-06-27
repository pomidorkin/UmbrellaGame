using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] GameObject umbrella;
    private float offset = 3.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, umbrella.transform.position.y - offset, -10);
    }
}
