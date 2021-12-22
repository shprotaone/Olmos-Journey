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
        BonusView(index, true);
        print("DisplayOn" + index);

        _slider[index].maxValue = duration;
        _slider[index].value = duration;
        _sprite[index].sprite = image;

        if (index == 0)
        {
            StartCoroutine(FadeSlider(index,duration));
        }
        else if (index == 1)
        {
            StartCoroutine(FadeSlider1(index,duration));
        }            
    }

    private IEnumerator FadeSlider(int index,float duration)
    {
        _slider[index].value = duration;
        float fadeTime = 1f;

        while (_slider[index].value > 0)
        {
            _slider[index].value -= fadeTime;
            yield return new WaitForSeconds(1f);
        }
        print("DisplayOff " + index);
        BonusView(index, false);

        yield break;
    }

    private IEnumerator FadeSlider1(int index,float duration)
    {
        _slider[index].value = duration;
        float fadeTime = 1f;

        while (_slider[index].value > 0)
        {
            _slider[index].value -= fadeTime;
            yield return new WaitForSeconds(1f);
        }
        print("DisplayOff " + index);
        BonusView(index, false);

        yield break;
    }

    public void BonusView(int index, bool condition)
    {
        _slider[index].gameObject.SetActive(condition);
        _sprite[index].gameObject.SetActive(condition);
    }

    public void ResetView(int index)
    {
        if(index == 0)
        {
            StopCoroutine(FadeSlider(index,0));
        }
        else if(index == 0)
        {
            StopCoroutine(FadeSlider1(index,0));
        }
        BonusView(index, false);
    }
}
