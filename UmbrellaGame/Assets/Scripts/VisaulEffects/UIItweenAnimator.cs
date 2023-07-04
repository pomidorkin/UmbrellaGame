using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItweenAnimator : MonoBehaviour
{
    [SerializeField] float degrees = 15;
    [SerializeField] float animTime = 2;
    void Start()
    {
        iTween.RotateTo(gameObject, iTween.Hash("z", degrees, "time", animTime, "islocal", true, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutQuad));
    }
}
