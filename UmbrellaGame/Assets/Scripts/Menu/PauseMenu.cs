using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GamePause gamePause;

    private void OnEnable()
    {
        gamePause.PauseGame();
    }

    public void HideMenu()
    {
        gameObject.SetActive(false);
    }
}
