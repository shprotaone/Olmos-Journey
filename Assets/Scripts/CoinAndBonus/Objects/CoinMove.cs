using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 17;     //добавить скорость отлета в балансер? 

    private Coin _coin;

    private void Start()
    {
        _coin = gameObject.GetComponent<Coin>();
    }

    private void Update()
    {
        if(_coin.PlayerTransform != null)
        this.transform.position = Vector3.MoveTowards(transform.position, _coin.PlayerTransform.position, _moveSpeed * Time.deltaTime);
    }

}
