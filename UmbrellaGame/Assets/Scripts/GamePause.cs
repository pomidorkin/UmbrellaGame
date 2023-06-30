using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    [SerializeField] GameObject gameLostMenu;
    [SerializeField] GameObject gamePausedMenu;
    [SerializeField] UmbrellaMovement umbrellaMovement;
    [SerializeField] UmbrellaController umbrellaController;
    [SerializeField] Button[] buttons;
    [SerializeField] ScoreCounter scoreCounter;
    [SerializeField] InterAd interAd;
    public static bool gameIsPaused = false;

    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void OpenGameLostMenu()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
        umbrellaMovement.DisableMovement();
        umbrellaController.DisableMovement();
        StartCoroutine(OpenGameLostMenuCoroutine());
    }

    public void CloseGameLostMenu()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
        umbrellaMovement.EnableMovement();
        umbrellaController.EnableMovement();
        gameLostMenu.SetActive(false);
    }

    private IEnumerator OpenGameLostMenuCoroutine()
    {
        yield return new WaitForSeconds(2f);
        PauseGame();
        gameLostMenu.SetActive(true);
        scoreCounter.UpdateHighScore();
        if (!SaveManager.Instance.State.disableAddsPurchased)
        {
            interAd.LoadAd();
        }
    }

    public void HideAllMenus()
    {
        Resume();
        gamePausedMenu.SetActive(false);
        gameLostMenu.SetActive(false);
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }

    public void PlayInterAd()
    {
        interAd.ShowAd();
    }
}
