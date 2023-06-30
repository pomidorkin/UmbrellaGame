using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPowerUpFX : MonoBehaviour
{
    [SerializeField] private AudioClip timeSlowedClip;
    [SerializeField] private AudioClip timeRestoredClip;

    public void PlaySlowedSound()
    {
        SoundManager.Instance.PlaySound(timeSlowedClip);
    }

    public void PlayRestoredSound()
    {
        SoundManager.Instance.PlaySound(timeRestoredClip);
    }
}
