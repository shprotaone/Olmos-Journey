using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabZones;
    [SerializeField] private Transform _lineVariant;

    private GameObject _currentZone;

    private Transform[] _linesForZone;
    private Transform _currentPos;

    private int[] _chanceBalance;
    private int _parentIndex;

    private void Awake()
    {
        _chanceBalance = LoadBalance.chancesZones;

        _linesForZone = _lineVariant.GetComponentsInChildren<Transform>();

        FindParent();

        _currentPos = _linesForZone[_parentIndex];

    }

    private void FindParent()
    {
        _parentIndex = Random.Range(1, _linesForZone.Length);
    }

    public void InstantiateZone(int index)
    {
        int currentRandom = index;

        for (int i = 0; i < _chanceBalance.Length; i++)
        {
            if (currentRandom <= _chanceBalance[i])
            {
                _currentZone = _prefabZones[i];
                Instantiate(_currentZone, _currentPos);
                return;
            }
            else
            {
                currentRandom -= _chanceBalance[i];
            }
        }
        
        print("Zone " + _currentZone);
    }
}
