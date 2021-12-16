using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class SettingsSaver : MonoBehaviour
{
    private const string musicName = "Music";
    private const string sfxName = "SFX";

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private GameSettings _gameSettingsContainer;
    [SerializeField] private Slider[] _sliders;

    private float _music;
    private float _sfx;

    private Toggle _drunkedCam;

    public float Music { get { return _music; } }
    public float SFX { get { return _sfx; } }

    private void Start()
    {
        _music = _gameSettingsContainer.music;
        _sfx = _gameSettingsContainer.sfx;
    }

    public void SetMusic(float volume)
    {
        _audioMixer.SetFloat(musicName, volume);
        _gameSettingsContainer.music = volume;
    }

    public void SetSFX(float volume)
    {
        _audioMixer.SetFloat(sfxName, volume);
        _gameSettingsContainer.sfx = volume;
    }

    public void LoadSettings(float music,float sfx)
    {
        _audioMixer.SetFloat(musicName, music);
        _audioMixer.SetFloat(sfxName, sfx);

        _sliders[0].value = music;
        _sliders[1].value = sfx;
    }
}
