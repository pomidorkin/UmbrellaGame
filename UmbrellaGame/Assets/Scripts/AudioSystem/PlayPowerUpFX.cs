using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPowerUpFX : MonoBehaviour
{
    [SerializeField] private AudioClip timeSlowedClip;
    [SerializeField] private AudioClip timeRestoredClip;
    [SerializeField] private AudioClip bubbleClip;

    public void PlaySlowedSound()
    {
        SoundManager.Instance.PlaySound(timeSlowedClip);
    }

    public void PlayRestoredSound()
    {
        SoundManager.Instance.PlaySound(timeRestoredClip);
    }

    public void PlayBubbleSound()
    {
        SoundManager.Instance.PlaySound(bubbleClip);
    }
}
