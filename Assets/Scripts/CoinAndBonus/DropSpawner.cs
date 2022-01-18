using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    [SerializeField] private CurrentGameDataContainer _gameData;
    [SerializeField] private DropList _prefabDrops;
    [SerializeField] private GameObject _bonusPositionPrefab;
    [SerializeField] private Transform _lineVariant;

    private GameObject _currentDrop;

    private Transform[] _linesForBonus;
    private Transform _currentPos;
    private Transform _bonusLine;

    private int[] _chanceBalance;
    private int _parentIndex;

    private void Start()
    {
        _chanceBalance = LoadBalance.chancesBonus;

        _linesForBonus = _lineVariant.GetComponentsInChildren<Transform>();

        FindParent();

        _bonusLine = _linesForBonus[_parentIndex];

        SetupPosition();
    }

    private void FindParent()   //поиск доступных точек
    {
        _parentIndex = Random.Range(1, _linesForBonus.Length);
    }

    private void SetupPosition()    //присвоение позиции
    {
        GameObject posInit = Instantiate(_bonusPositionPrefab, _bonusLine);
        _currentPos = posInit.GetComponentInChildren<Transform>();
    }

    private bool CheckDuplicate()
    {
        bool checkType = _currentDrop.GetHashCode() == _gameData.previousBonus.GetHashCode();

        if (_gameData.previousBonus != null && checkType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void InstantiateBonus(int index) //размещение бонуса
    {
        int currentRandom = index;

        for (int i = 0; i < _chanceBalance.Length; i++)
        {
            if (currentRandom <= _chanceBalance[i])
            {
                _currentDrop = _prefabDrops.dropPrefabs[i];

                if (CheckDuplicate()) _currentDrop = _prefabDrops.NextPrefab(i);

                _gameData.previousBonus = _currentDrop;
                Instantiate(_currentDrop, _currentPos);

                return;
            }
            else
            {
                currentRandom -= _chanceBalance[i];
            }
        }
    }
}
