using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] BoxCollider2D[] umbrellaColliders;
    private bool powerupIsActive = false;
    [SerializeField] PlayPowerUpFX powerUpSoundFX;
    [SerializeField] GameObject bubbleSprite;

    public void ActivateBubble()
    {
        if (!powerupIsActive)
        {
            // TODO: Play pick up audio effect
            // Work with sprites
            bubbleSprite.SetActive(true);
            foreach (BoxCollider2D collider in umbrellaColliders)
            {
                collider.enabled = false;
            }
            powerupIsActive = true;
            StartCoroutine(EnableCollidersCoroutine());
        }
    }

    private IEnumerator EnableCollidersCoroutine()
    {
        yield return new WaitForSeconds(5f);
        foreach (BoxCollider2D collider in umbrellaColliders)
        {
            collider.enabled = true;
        }
        powerupIsActive = false;
        bubbleSprite.SetActive(false);
    }

    public void ActivateTimeSlower()
    {
        if (!powerupIsActive)
        {
            // TODO: Play time slowing audio effect
            powerUpSoundFX.PlaySlowedSound();
            Time.timeScale = 0.5f;
            powerupIsActive = true;
            StartCoroutine(ReturnTimeToNormalCoroutine());
        }
    }

    private IEnumerator ReturnTimeToNormalCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
        powerUpSoundFX.PlayRestoredSound();
        powerupIsActive = false;
    }
}