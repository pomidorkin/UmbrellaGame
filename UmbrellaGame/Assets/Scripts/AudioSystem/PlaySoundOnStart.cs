using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    public void PlaySound()
    {
        //SoundManager.Instance.PlaySound(_clip);
        SoundManager.Instance.PlaySoundAaptiveVolume(_clip, 0.3f);
    }
}
