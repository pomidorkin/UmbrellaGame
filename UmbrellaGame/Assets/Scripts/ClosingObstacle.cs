using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingObstacle : MonoBehaviour
{
    [SerializeField] private bool isRight = false;
    // Start is called before the first frame update
    void Start()
    {
        if (isRight)
        {
            iTween.MoveTo(gameObject, iTween.Hash("x", 3, "time", 2, "islocal", true, "looptype", "pingpong", "easetype", iTween.EaseType.easeInBack));
        }
        else
        {
            iTween.MoveTo(gameObject, iTween.Hash("x", -3, "time", 2, "islocal", true, "looptype", "pingpong", "easetype", iTween.EaseType.easeInBack));
        }
    }
}
