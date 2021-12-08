using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabZones;
    [SerializeField] private GameObject _bonusPositionPrefab;
    [SerializeField] private Transform _lineVariant;

    private GameObject _currentZone;

    private Transform[] _linesForZone;
    private Transform _currentPos;
    private Transform _bonusLine;

    private int[] _chanceBalance;
    private int _parentIndex;

    private void Start()
    {
        _chanceBalance = LoadBalance.chancesZones;

        _linesForZone = _lineVariant.GetComponentsInChildren<Transform>();

        FindParent();

        _bonusLine = _linesForZone[_parentIndex];

        SetupPosition();
    }

    private void FindParent()
    {
        _parentIndex = Random.Range(1, _linesForZone.Length);
    }

    private void SetupPosition()
    {
        GameObject posInit = Instantiate(_bonusPositionPrefab, _bonusLine);
        _currentPos = posInit.GetComponentInChildren<Transform>();
    }

    public void InstantiateZone(int index)
    {
        for (int i = 0; i < _chanceBalance.Length; i++)
        {
            if (index <= _chanceBalance[i])
            {
                _currentZone = _prefabZones[i];
            }
            else
            {
                index -= _chanceBalance[i];
            }
        }

        Instantiate(_currentZone, _currentPos);
    }
}
