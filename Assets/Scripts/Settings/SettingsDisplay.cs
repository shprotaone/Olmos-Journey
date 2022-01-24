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

    [SerializeField] private Sprite[] _turnOnSfx;
    [SerializeField] private Sprite[] _turnOffSfx;

    [SerializeField] private Image[] _currentImage;

    [SerializeField] private CommonSoundController _soundController;

    private void Start()
    {
        _currentImage = new Image[2];
        LoadCurrentSettings();
    }

    private void LoadCurrentSettings()
    {

        Sprite[] switchSprite;

        _currentImage = _musicButton.GetComponentsInChildren<Image>();
       
        if (_soundController.Music)
            switchSprite = _turnOnMusic;
        else switchSprite = _turnOffMusic;

        SwitchImage(_soundController.Music, _currentImage, switchSprite);

        _currentImage = _soundsButton.GetComponentsInChildren<Image>();

        if (_soundController.SFX)
            switchSprite = _turnOnSfx;
        else switchSprite = _turnOffSfx;

        SwitchImage(_soundController.SFX, _currentImage, switchSprite);
    }

    public void ChangeMusic()
    {
        _currentImage = _musicButton.GetComponentsInChildren<Image>();
        Sprite[] switchSprite;        
       
        if (_soundController.Music)
        {
            switchSprite = _turnOnMusic;
            SwitchImage(_soundController.Music, _currentImage,switchSprite);
        }
        else
        {
            switchSprite = _turnOffMusic;
            SwitchImage(_soundController.Music,_currentImage,switchSprite);
        }
    }

    public void ChangeSounds()
    {
        _currentImage = _soundsButton.GetComponentsInChildren<Image>();

        Sprite[] switchSprite;
        if (_soundController.SFX)
        {
            switchSprite = _turnOnSfx;
            SwitchImage(_soundController.SFX, _currentImage,switchSprite);
        }
        else
        {
            switchSprite = _turnOffSfx;
            SwitchImage(_soundController.SFX, _currentImage,switchSprite);
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
