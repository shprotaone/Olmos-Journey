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
    [SerializeField] private GameSettings _gameSettingsContainer;
    [SerializeField] private SettingsDisplay _settingDisplay;

    private bool _music;
    private bool _sfx;

    private Toggle _drunkedCam;

    public bool Music { get { return _music; } }
    public bool SFX { get { return _sfx; } }

    private void Start()
    {
        _music = _gameSettingsContainer.music;
        _sfx = _gameSettingsContainer.sfx;
    }

    public bool Convertation(string value)
    {
        if (value == "True")
            return true;
        else return false;
    }

    public void LoadSettings(bool music,bool sounds)
    {
        _gameSettingsContainer.music = music;
        _gameSettingsContainer.sfx = sounds;

        SetMusic();
        SetSFX();
    }

    public void SetMusic()
    {
        _music = _gameSettingsContainer.music;

        if (_music)
        {
            _audioMixer.SetFloat(sfxName, 0);
        }
        else
        {
            _audioMixer.SetFloat(sfxName, -80);
        }
    }

    public void SetSFX()
    {
        _sfx = _gameSettingsContainer.sfx;

        if (_sfx)
        {
            _audioMixer.SetFloat(musicName, 0);
        }
        else
        {
            _audioMixer.SetFloat(musicName, -80);
        }
    }

    public void SwitchMusic()
    {
        if (_gameSettingsContainer.music)
        {
            _gameSettingsContainer.music = false;
        }
        else
        {
            _gameSettingsContainer.music = true;
        }
        _settingDisplay.ChangeMusic();
        SetMusic();
        
    }

    public void SwitchSounds()
    {
        if (_gameSettingsContainer.sfx)
        {
            _gameSettingsContainer.sfx = false;
        }
        else
        {
            _gameSettingsContainer.sfx = true;
        }

        _settingDisplay.ChangeSounds();
        SetSFX();
    }
}
