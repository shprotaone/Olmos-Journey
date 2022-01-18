using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyCoinScript : MonoBehaviour
{
    private const int indexDisplay = 1;

    [SerializeField] private Sprite _spriteBonus;
    [SerializeField] private BonusDisplay _bonusDisplay;
    private int _coinMultiply = 1;
    private float _activeTime = 11;
    private float _currentTime;
    private bool _multiplyActive;

    public int CoinMultiply { get { return _coinMultiply; } }

    public void EnableMultiply()
    {
        if (!_multiplyActive) StartCoroutine(MultiplyScore());
        else _currentTime = _activeTime;
    }

    private IEnumerator MultiplyScore()
    {
        _coinMultiply = LoadBalance.scoreMultiplyBonusValue;
        _currentTime = _activeTime;

        float perTime = 1f;

        while (_currentTime > 0)
        {
            _multiplyActive = true;
            _currentTime -= perTime;

            _bonusDisplay.BonusOn(indexDisplay, _activeTime, _currentTime, _spriteBonus);

            yield return new WaitForSeconds(1f);
        }

        _multiplyActive = false;
        _bonusDisplay.BonusOn(indexDisplay, _activeTime, _currentTime, _spriteBonus);

        _coinMultiply = 1;

        yield break;
    }
}
