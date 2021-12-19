using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusDisplay : MonoBehaviour
{
    [SerializeField] private Image[] _sprite;
    [SerializeField] private Slider[] _slider;

    public void BonusOn(int index,float duration,Sprite image)
    {
        StopAllCoroutines();
        BonusView(index, true);

        _slider[index].maxValue = duration;
        _slider[index].value = duration;
        _sprite[index].sprite = image;

        StartCoroutine(FadeSlider(index, duration));
    }

    private IEnumerator FadeSlider(int index, float value)
    {
        float fadeTime = 1f;

        while (_slider[index].value > 0)
        {
            _slider[index].value -= fadeTime;
            yield return new WaitForSeconds(1f);
        }

        BonusView(index, false);

        yield break;
    }

    private void BonusView(int index, bool condition)
    {
        _slider[index].gameObject.SetActive(condition);
        _sprite[index].gameObject.SetActive(condition);
    }
}
