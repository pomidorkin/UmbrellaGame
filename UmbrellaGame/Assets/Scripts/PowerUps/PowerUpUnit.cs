using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpUnit : MonoBehaviour
{
    [SerializeField] PowerUpController powerUpController;
    [SerializeField] GameObject bubblePowerUp;
    [SerializeField] GameObject timeslowerPowerUp;
    private void OnEnable()
    {
        int rnd = Random.Range(1, 3);
        if (rnd == 1)
        {
            powerUpController.ActivateBubble();
            bubblePowerUp.SetActive(true);
        }
        else
        {
            powerUpController.ActivateTimeSlower();
            timeslowerPowerUp.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Umbrella")
        {
            bubblePowerUp.SetActive(false);
            timeslowerPowerUp.SetActive(false);
        }
    }
}
