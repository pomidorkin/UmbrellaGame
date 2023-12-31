using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] Collider2D[] umbrellaColliders;
    public bool powerupIsActive = false;
    public bool powerUpIsSpawned = false;
    [SerializeField] PlayPowerUpFX powerUpSoundFX;
    [SerializeField] GameObject bubbleSprite;
    private bool isInvulnerable = false;

    public void ActivateBubble()
    {
        if (!powerupIsActive)
        {
            // TODO: Play pick up audio effect
            // Work with sprites
            bubbleSprite.SetActive(true);
            foreach (Collider2D collider in umbrellaColliders)
            {
                collider.enabled = false;
            }
            powerUpSoundFX.PlayBubbleSound();
            powerupIsActive = true;
            StartCoroutine(EnableCollidersCoroutine());
            isInvulnerable = true;
        }
    }

    private IEnumerator EnableCollidersCoroutine()
    {
        yield return new WaitForSeconds(5f);
        foreach (Collider2D collider in umbrellaColliders)
        {
            collider.enabled = true;
        }
        powerUpSoundFX.PlayBubbleSound();
        powerupIsActive = false;
        bubbleSprite.SetActive(false);
        isInvulnerable = false;
    }

    public bool GetIsInvulnerable()
    {
        return isInvulnerable;
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