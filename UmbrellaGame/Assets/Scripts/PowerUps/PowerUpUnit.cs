using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpUnit : MonoBehaviour
{
    [SerializeField] PowerUpController powerUpController;
    [SerializeField] GameObject bubblePowerUp;
    [SerializeField] GameObject timeslowerPowerUp;
    private int powerUpId = 0;
    private void OnEnable()
    {
        int rnd = Random.Range(1, 3);
        Debug.Log("rnd: " + rnd);
        if (rnd == 1)
        {
            powerUpId = 1;
            bubblePowerUp.SetActive(true);
        }
        else if (rnd == 2)
        {
            powerUpId = 2;
            timeslowerPowerUp.SetActive(true);
        }
        powerUpController.powerUpIsSpawned = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Umbrella")
        {
            if (powerUpId == 1)
            {
                powerUpController.ActivateBubble();
            }
            else if (powerUpId == 2)
            {
                powerUpController.ActivateTimeSlower();
            }
            powerUpId = 0;
            bubblePowerUp.SetActive(false);
            timeslowerPowerUp.SetActive(false);
            //powerUpController.powerupIsActive = false;
            powerUpController.powerUpIsSpawned = false;
            gameObject.SetActive(false);
        }
    }

    public void DisablePowerUp()
    {
        powerUpController.powerupIsActive = false;
        powerUpId = 0;
        bubblePowerUp.SetActive(false);
        timeslowerPowerUp.SetActive(false);
        gameObject.SetActive(false);
    }
}
