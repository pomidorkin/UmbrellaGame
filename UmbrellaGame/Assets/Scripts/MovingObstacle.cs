using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("x", 1.3, "time", 3, "islocal", true, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutQuad));
    }
}
