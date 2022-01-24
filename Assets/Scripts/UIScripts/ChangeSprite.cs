using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    private Image _currentImage;

    private void Start()
    {
        _currentImage = GetComponent<Image>();
        RefreshImage();
        LocalizationManager.OnLanguageChanged += RefreshImage;
    }

    public void RefreshImage()
    {
        _currentImage.sprite = _sprites[LocalizationManager.CurrentLanguage];
    }

    private void OnDestroy()
    {
        LocalizationManager.OnLanguageChanged -= RefreshImage;
    }
}
