using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusDisplay : MonoBehaviour
{
    [SerializeField] private Image _sprite;
    [SerializeField] private Slider _slider;

    public void BonusOn(float duration,Sprite image)
    {
        StopAllCoroutines();
        BonusView(true);

        _slider.maxValue = duration;
        _slider.value = duration;
        _sprite.sprite = image;

        StartCoroutine(FadeSlider(duration));
    }

    private IEnumerator FadeSlider(float value)
    {
        float fadeTime = 1f;

        while (_slider.value > 0)
        {
            _slider.value -= fadeTime;
            yield return new WaitForSeconds(1f);
        }

        BonusView(false);

        yield break;
    }

    private void BonusView(bool condition)
    {
        _slider.gameObject.SetActive(condition);
        _sprite.gameObject.SetActive(condition);
    }
}
