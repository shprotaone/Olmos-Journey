using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _gift;
    [SerializeField] int _chance;

    public void SpawnBonus()
    {
        _gift.SetActive(Random.Range(0, 101) <= _chance);
    }
}
