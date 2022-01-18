using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusDisplay : MonoBehaviour
{
    [SerializeField] private Image[] _sprite;
    [SerializeField] private Slider[] _slider;

    private int coroutineIsStarted;

    public void BonusOn(int index, float duration,float currentTime, Sprite image)
    {
        _slider[index].maxValue = duration;
        _slider[index].value = currentTime;
        
        BonusView(index, true);

        if(_slider[index].value==0)
        {
            BonusView(index,false);
        }

        _sprite[index].sprite = image;
    }

    public void BonusView(int index, bool condition)
    {
        _slider[index].gameObject.SetActive(condition);
        _sprite[index].gameObject.SetActive(condition);
    }
}
