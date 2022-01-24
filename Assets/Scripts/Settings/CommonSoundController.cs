using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommonSoundController : MonoBehaviour
{
    private const string musicName = "Music";
    private const string sfxName = "SFX";

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private SettingsDisplay _settingDisplay;
    [SerializeField] private GamePreferencesManager _gamePreferencesManager;
    [SerializeField] private GameSettings _gameSettings;

    private bool _music;
    private bool _sfx;

    private Toggle _drunkedCam;

    public bool SFX { get { return _sfx; } }
    public bool Music { get { return _music; } }

    private void Start()
    {
        _music = _gameSettings.music;
        _sfx = _gameSettings.sfx;

        LoadSettings();
    }

    /// <summary>
    /// Загрузка текущих настроек
    /// </summary>
    /// <param name="music"></param>
    /// <param name="sounds"></param>
    public void LoadSettings()
    {
        SetSound(musicName,_music);
        SetSound(sfxName,_sfx);
    }

    private void SetSound(string soundLayer,bool value)
    {
        if (value)
        {
            _audioMixer.SetFloat(soundLayer, 0);
        }
        else
        {
            _audioMixer.SetFloat(soundLayer, -80);
        }
    }

    public void SwitchMusic()
    {
        if (_music)
        {
            _music = false;
        }
        else
        {
            _music = true;
        }

        _settingDisplay.ChangeMusic();
        SetSound(musicName,_music);
    }

    public void SwitchSFX()
    {
        if (_sfx)
        {
            _sfx = false;
        }
        else
        {
            _sfx = true;
        }

        _settingDisplay.ChangeSounds();
        SetSound(sfxName,_sfx);
    }
}
