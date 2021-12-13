using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabCoins;    
    [SerializeField] private GameObject _coinsPositionPrefab;
    [SerializeField] private Transform _lineVariant;

    private GameObject _currentCoin;

    private Transform[] _linesForBonus;
    private Transform _currentPos;   
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
    private void FindParent()   //определяем лайн
    {
        _parentIndex = Random.Range(1, _linesForBonus.Length);
    }

    private void SetupPosition()
    {
        GameObject posInit = Instantiate(_coinsPositionPrefab, _bonusLine);
        _currentPos = posInit.GetComponentInChildren<Transform>();       
    }

    public void InstantiateCoin(int index)
    {
        int currentRandomNumber = index;

        for (int i = 0; i < _chancesCoin.Length; i++)
        {
            if (currentRandomNumber <= _chancesCoin[i])
            {
                _currentCoin = prefabCoins[i];
                Instantiate(_currentCoin, _currentPos);
                return;
            }
            else
            {
                currentRandomNumber -= _chancesCoin[i];
            }
        }
        print("Coin " + _currentCoin.name);
    }
}
