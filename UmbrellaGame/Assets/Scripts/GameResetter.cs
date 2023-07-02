using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResetter : MonoBehaviour
{
    [SerializeField] CameraFollowScript cameraFollowScript;
    [SerializeField] GamePause gameMenu;
    public delegate void ResetGame();
    public event ResetGame OnGameReset;

    // Variables for continuing
    [SerializeField] BoxCollider2D[] umbrellaColliders;
    [SerializeField] GamePause pauseController;
    [SerializeField] RewardedAdController rewardedAdController;

    public void TryAgain()
    {
        OnGameReset();
        cameraFollowScript.ResetCameraPos();
        gameMenu.HideAllMenus();
    }

    public void ContinuePlaying()
    {
        foreach (BoxCollider2D collider in umbrellaColliders)
        {
            collider.enabled = false;
        }
        gameMenu.DisableGameLostObstacle();
        pauseController.Resume();
        pauseController.CloseGameLostMenu();
        StartCoroutine(EnableCollidersCoroutine());
        rewardedAdController.LoadAd();
    }

    private IEnumerator EnableCollidersCoroutine()
    {
        yield return new WaitForSeconds(3f);
        foreach (BoxCollider2D collider in umbrellaColliders)
        {
            collider.enabled = true;
        }
    }
}
