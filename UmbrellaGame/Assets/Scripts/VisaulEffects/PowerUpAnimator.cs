using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", .5, "time", 2, "islocal", true, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutQuad));
    }
}