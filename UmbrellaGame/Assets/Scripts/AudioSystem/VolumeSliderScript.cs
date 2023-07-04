using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderScript : MonoBehaviour
{
    [SerializeField] private Slider _effectsVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;

    // Icons
    [SerializeField] GameObject musicMuteIcon;
    [SerializeField] GameObject musicLoudIcon;
    [SerializeField] GameObject effectsMuteIcon;
    [SerializeField] GameObject effectsLoudIcon;

    private void Start()
    {
        SoundManager.Instance.ChangeEffectsVolume(_effectsVolumeSlider.value);
        SoundManager.Instance.ChangeMusicVolume(_musicVolumeSlider.value);
        if (_effectsVolumeSlider.value <= 0)
        {
            effectsMuteIcon.SetActive(true);
            effectsLoudIcon.SetActive(false);
        }
        if (_musicVolumeSlider.value <= 0)
        {
            musicMuteIcon.SetActive(true);
            musicLoudIcon.SetActive(false);
        }
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
            effectsMuteIcon.SetActive(true);
            effectsLoudIcon.SetActive(false);
        }
        else
        {
            effectsMuteIcon.SetActive(false);
            effectsLoudIcon.SetActive(true);
        }
    }

    public void MusicValueChangeCheck()
    {
        SoundManager.Instance.ChangeMusicVolume(_musicVolumeSlider.value);
        if (_musicVolumeSlider.value <= 0)
        {
            musicMuteIcon.SetActive(true);
            musicLoudIcon.SetActive(false);
        }
        else
        {
            musicMuteIcon.SetActive(false);
            musicLoudIcon.SetActive(true);
        }
    }
}
