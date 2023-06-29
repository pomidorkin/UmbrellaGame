using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsVolumeSetter : MonoBehaviour
{
    [SerializeField] MusicVulomeSetter musicVulomeSetter;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider effectsSlider;
    private void OnEnable()
    {
        musicSlider.value = musicVulomeSetter.saveManager.State.musicVolume;
        effectsSlider.value = musicVulomeSetter.saveManager.State.soundsVolume;
    }

    private void OnDisable()
    {
        musicVulomeSetter.saveManager.State.soundsVolume = effectsSlider.value;
        musicVulomeSetter.saveManager.State.musicVolume = musicSlider.value;
        SaveManager.Instance.Save();
    }
}
