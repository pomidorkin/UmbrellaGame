using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaSpriteController : MonoBehaviour
{
    [SerializeField] GameResetter gameResetter;
    private void OnEnable()
    {
        gameResetter.OnGameReset += RotateStraight;
    }

    private void OnDisable()
    {
        gameResetter.OnGameReset -= RotateStraight;
    }
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
