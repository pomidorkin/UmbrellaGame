using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItweenAnimator : MonoBehaviour
{
    void Start()
    {
        iTween.RotateTo(gameObject, iTween.Hash("z", 15, "time", 2, "islocal", true, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutQuad));
    }
}
