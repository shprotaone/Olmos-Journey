using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _musicButton;
    [SerializeField] private GameObject _soundsButton;

    [SerializeField] private Sprite[] _turnOnMusic;
    [SerializeField] private Sprite[] _turnOffMusic;

    [SerializeField] private Sprite[] _turnOnSounds;
    [SerializeField] private Sprite[] _turnOffSounds;

    [SerializeField] private Image[] _currentImage;

    [SerializeField] private GameSettings _settings;
    [SerializeField] private CommonSoundController _soundController;

    private void Start()
    {
        _currentImage = new Image[2];
        LoadCurrentSettings();
    }

    private void LoadCurrentSettings()
    {
        _currentImage = _musicButton.GetComponentsInChildren<Image>();
        Sprite[] switchSprite;

        if (_settings.music)
            switchSprite = _turnOnMusic;
        else switchSprite = _turnOffMusic;

        SwitchImage(_settings.music, _currentImage, switchSprite);

        _currentImage = _soundsButton.GetComponentsInChildren<Image>();

        if (_settings.music)
            switchSprite = _turnOnSounds;
        else switchSprite = _turnOffSounds;

        SwitchImage(_settings.sfx, _currentImage, switchSprite);
    }

    public void ChangeMusic()
    {
        _currentImage = _musicButton.GetComponentsInChildren<Image>();
        Sprite[] switchSprite;        
       
        if (_settings.music)
        {
            switchSprite = _turnOnMusic;
            SwitchImage(_settings.music,_currentImage,switchSprite);
        }
        else
        {
            switchSprite = _turnOffMusic;
            SwitchImage(_settings.music,_currentImage,switchSprite);
        }
    }

    public void ChangeSounds()
    {
        _currentImage = _soundsButton.GetComponentsInChildren<Image>();

        Sprite[] switchSprite;
        if (_settings.sfx)
        {
            switchSprite = _turnOnSounds;
            SwitchImage(_settings.sfx,_currentImage,switchSprite);
        }
        else
        {
            switchSprite = _turnOffSounds;
            SwitchImage(_settings.sfx,_currentImage,switchSprite);
        }
    }

    private void SwitchImage(bool stats, Image[] currentImage,Sprite[] switchSprite)
    {      
        if (stats)
        {
            for (int i = 0; i < _currentImage.Length; i++)
            {
                currentImage[i].sprite = switchSprite[i];
            }
        }
        else
        {
            for (int i = 0; i < _currentImage.Length; i++)
            {
                currentImage[i].sprite = switchSprite[i];
            }
        }        
    }   
}
