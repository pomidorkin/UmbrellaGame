using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GamePause pauseController;
    [SerializeField] GameObject parentObstacle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Umbrella")
        {
            pauseController.OpenGameLostMenu();
            Debug.Log("Game Lost!");
            pauseController.SetGameLostObstacle(parentObstacle);
        }
        if (!SaveManager.Instance.State.disableAddsPurchased)
        {
            SaveManager.Instance.State.timesDied++;

            if (SaveManager.Instance.State.timesDied >= 5)
            {
                SaveManager.Instance.State.timesDied = 0;
                pauseController.PlayInterAd();
            }

            SaveManager.Instance.Save();
        }
    }
}
