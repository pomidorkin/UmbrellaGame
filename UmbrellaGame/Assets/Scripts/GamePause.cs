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
            button.enabled = false;
        }
        umbrellaMovement.DisableMovement();
        umbrellaController.DisableMovement();
        StartCoroutine(OpenGameLostMenuCoroutine());
    }

    private IEnumerator OpenGameLostMenuCoroutine()
    {
        yield return new WaitForSeconds(2f);
        PauseGame();
        gameLostMenu.SetActive(true);
        scoreCounter.UpdateHighScore();
    }

    public void HideAllMenus()
    {
        Resume();
        gamePausedMenu.SetActive(false);
        gameLostMenu.SetActive(false);
        foreach (Button button in buttons)
        {
            button.enabled = true;
        }
    }
}
