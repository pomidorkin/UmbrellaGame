using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVulomeSetter : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public SaveManager saveManager;
    // Start is called before the first frame update
    void Start()
    {
        saveManager = SaveManager.Instance;
        SaveManager.Instance.Load();

        soundManager.ChangeEffectsVolume(SaveManager.Instance.State.soundsVolume);
        soundManager.ChangeMusicVolume(SaveManager.Instance.State.musicVolume);
    }
}
