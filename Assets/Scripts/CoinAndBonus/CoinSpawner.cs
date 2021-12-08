using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabCoins;    
    [SerializeField] private GameObject _coinsPositionPrefab;
    [SerializeField] private Transform _lineVariant;

    private GameObject _currentBonus;

    private Transform[] _linesForBonus;
    private Transform[] _coinPos;   
    private Transform _bonusLine;

    private int[] _chancesCoin;   
    private int _parentIndex;

    private void Start()
    {
        _chancesCoin = LoadBalance.chancesCoin;

        _linesForBonus = _lineVariant.GetComponentsInChildren<Transform>();
       
        FindParent();

        _bonusLine = _linesForBonus[_parentIndex];
        
        SetupPosition();
               
    }
    private void FindParent()
    {
        _parentIndex = Random.Range(1, _linesForBonus.Length);
    }

    private void SetupPosition()
    {
        GameObject posInit = Instantiate(_coinsPositionPrefab, _bonusLine);
        _coinPos = posInit.GetComponentsInChildren<Transform>();       
    }

    public void InstantiateCoin(int index)
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
}
