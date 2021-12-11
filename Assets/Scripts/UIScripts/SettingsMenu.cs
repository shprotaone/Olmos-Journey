using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    private const string musicName = "Music";
    private const string sfxName = "SFX";

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private GameSettings _settingsContainer;
    
    private Slider[] _sliders;

    private void Awake()
    {
        _sliders = GetComponentsInChildren<Slider>();

        LoadSettings();
    }


    public void SetMusic(float volume)
    {
        _audioMixer.SetFloat(musicName, volume);
        _settingsContainer.music = volume;
    }

    public void SetSFX(float volume)
    {
        _audioMixer.SetFloat(sfxName, volume);
        _settingsContainer.sfx = volume;
    }

    public void LoadSettings()
    {
        float music = _settingsContainer.music;
        float sfx = _settingsContainer.sfx;

        _audioMixer.SetFloat(musicName, music);
        _audioMixer.SetFloat(sfxName, sfx);

        _sliders[0].value = music;
        _sliders[1].value = sfx;
    }
}
