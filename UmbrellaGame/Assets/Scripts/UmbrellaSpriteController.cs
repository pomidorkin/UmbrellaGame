using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaSpriteController : MonoBehaviour
{
    public void RotateLeft()
    {
        iTween.RotateTo(gameObject, iTween.Hash("z", 5, "time", 1));
    }

    public void RotateRight()
    {
        iTween.RotateTo(gameObject, iTween.Hash("z", -5, "time", 1));
    }

    public void RotateStraight()
    {
        iTween.RotateTo(gameObject, iTween.Hash("z", 0, "time", 1));
    }
}
