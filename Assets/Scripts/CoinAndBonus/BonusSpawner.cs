using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabBonuses;
    [SerializeField] private GameObject _bonusPositionPrefab;
    [SerializeField] private Transform _lineVariant;

    private GameObject _currentBonus;

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

    private void FindParent()
    {
        _parentIndex = Random.Range(1, _linesForBonus.Length);
    }

    private void SetupPosition()
    {
        GameObject posInit = Instantiate(_bonusPositionPrefab, _bonusLine);
        _currentPos = posInit.GetComponentInChildren<Transform>();
    }

    public void InstantiateBonus(int index)
    {
        int currentRandom = index;

        for (int i = 0; i < _chanceBalance.Length; i++)
        {
            if (currentRandom <= _chanceBalance[i])
            {
                _currentBonus = _prefabBonuses[i];
                Instantiate(_currentBonus, _currentPos);
                return;
            }
            else
            {
                currentRandom -= _chanceBalance[i];
            }
        }
        
        print("Bonus " + _currentBonus.name);
    }
}
