using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderScript : MonoBehaviour
{
    [SerializeField] private Slider _effectsVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;

    private void Start()
    {
        SoundManager.Instance.ChangeEffectsVolume(_effectsVolumeSlider.value);
        SoundManager.Instance.ChangeMusicVolume(_musicVolumeSlider.value);
        //_effectsVolumeSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeEffectsVolume(val));
        //_musicVolumeSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));
        _effectsVolumeSlider.onValueChanged.AddListener(delegate { EffectsValueChangeCheck(); });
        _musicVolumeSlider.onValueChanged.AddListener(delegate { MusicValueChangeCheck(); });
    }

    public void EffectsValueChangeCheck()
    {
        SoundManager.Instance.ChangeEffectsVolume(_effectsVolumeSlider.value);
        if (_effectsVolumeSlider.value <= 0)
        {
            // Change icon to mute
        }
    }

    public void MusicValueChangeCheck()
    {
        SoundManager.Instance.ChangeMusicVolume(_musicVolumeSlider.value);
        if (_musicVolumeSlider.value <= 0)
        {
            // Change icon to mute
        }
    }
}
