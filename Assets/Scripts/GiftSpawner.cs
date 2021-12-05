using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabCoins;
    [SerializeField] private GameObject[] prefabBonus;
    [SerializeField] private GameObject _coinsPositionPrefab;
    [SerializeField] private GameObject _bonusPositionPrefab;

    [SerializeField] private Transform _lineVariant;
    private Transform[] _linesForBonus;
    private Transform _bonusLine;
    private int _parentIndex;

    private Transform[] _coinPos;
    private Transform _bonusPos;
    [SerializeField] private int _currentNumber;

    private int[] _chancesCoin;
    private int[] _chanceBonus;

    private int _total;
    private GameObject _currentBonus;

    private bool bonus;

    private void Start()
    {
        _linesForBonus = _lineVariant.GetComponentsInChildren<Transform>();
        bonus = TrueFalseRandomizer();

        _chancesCoin = new int[] { LoadBalance.chanceEmpty, LoadBalance.chanceGiftType1, LoadBalance.chanceGiftType2, LoadBalance.chanceGiftType3 };
        _chanceBonus = new int[] { LoadBalance.chanceEmpty, LoadBalance.chanceBonusType1, LoadBalance.chanceBonusType2, LoadBalance.chanceBonusType3 };

        FindParent();

        _bonusLine = _linesForBonus[_parentIndex];
        SetUpBonusPosition();

        if (!bonus)
        {
            InstantiateCoin(RandomSystem(_chancesCoin));           
        }
        else
        {
            InstantiateBonus(RandomSystem(_chanceBonus));
        }
               
    }
    private void FindParent()
    {
        _parentIndex = Random.Range(1, _linesForBonus.Length);
    }

    private void SetUpBonusPosition()
    {
        if (!bonus)
        {
            GameObject posInit = Instantiate(_coinsPositionPrefab, _bonusLine);
            _coinPos = posInit.GetComponentsInChildren<Transform>();
        }
        else
        {
            GameObject posInit = Instantiate(_bonusPositionPrefab,_bonusLine);
            _bonusPos = posInit.GetComponentInChildren<Transform>();            
        }              
    }

    public int RandomSystem(int[] variant)
    {
        int currentNumber;

        foreach (var item in _chancesCoin)
        {
            _total += item;
        }

        currentNumber = Random.Range(0, _total);

        return currentNumber;
    }

    private void InstantiateCoin(int index)
    {
        for (int i = 0; i < _chancesCoin.Length; i++)
        {
            if (index <= _chancesCoin[i])
            {
                _currentBonus = prefabCoins[i];
            }
            else
            {
                index -= _chancesCoin[i];
            }
        }

        for (int i = 0; i < _coinPos.Length; i++)
        {
            Instantiate(_currentBonus, _coinPos[i]);
        }
    }

    private void InstantiateBonus(int index)
    {
        for (int i = 0; i < _chancesCoin.Length; i++)
        {
            if (index <= _chancesCoin[i])
            {
                _currentBonus = prefabBonus[i];
            }
            else
            {
                index -= _chancesCoin[i];
            }
        }

        Instantiate(_currentBonus, _bonusPos);
    }

    private bool TrueFalseRandomizer()
    {
        int result = Random.Range(0, 100);

        return result <= 60;

    }
}
