using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    private const int indexDisplay = 0;

    [SerializeField] private GameObject _coinDetector;
    [SerializeField] private BonusDisplay _bonusDisplay;
    [SerializeField] private Sprite _magnetSprite;
    private float _activeTime = 11;
    private float _currentTime;

    private bool _magnetActivate;
    
    public Transform PlayerTransform { get; private set; }

    void OnEnable()
    {       
        PlayerTransform = GetComponentInParent<Transform>();
    }

    public void EnableMagnet()
    {
        _coinDetector.SetActive(true);

        if(!_magnetActivate)StartCoroutine(MagnetActivate());
        else _currentTime = _activeTime;
    }

   private IEnumerator MagnetActivate()
    {
        _currentTime = _activeTime;       
        float perTime = 1f;
       
        while (_currentTime > 0)
        {         
            _magnetActivate = true;
            _currentTime -= perTime;

            _bonusDisplay.BonusOn(indexDisplay,_activeTime, _currentTime ,_magnetSprite);

            yield return new WaitForSeconds(1f);
        }
        _magnetActivate = false;

        _bonusDisplay.BonusOn(indexDisplay,_activeTime, _currentTime ,_magnetSprite);

        _coinDetector.SetActive(false);

        yield break;
    }
}
