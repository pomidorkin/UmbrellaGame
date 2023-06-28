using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResetter : MonoBehaviour
{
    [SerializeField] CameraFollowScript cameraFollowScript;
    [SerializeField] GamePause gameMenu;
    public delegate void ResetGame();
    public event ResetGame OnGameReset;

    public void TryAgain()
    {
        OnGameReset();
        cameraFollowScript.ResetCameraPos();
        gameMenu.HideAllMenus();
    }
}
