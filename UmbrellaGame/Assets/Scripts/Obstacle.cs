using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GamePause pauseController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Umbrella")
        {
            pauseController.OpenGameLostMenu();
            Debug.Log("Game Lost!");
        }
    }
}
