using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject pauseMenu;

    public void OpenSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
}
