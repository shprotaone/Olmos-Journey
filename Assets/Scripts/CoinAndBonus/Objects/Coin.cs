using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : InterractableObject
{
    [SerializeField] private Transform _playerTransform;
    private GameObject _gift;
    private CoinMove _coinMoveScript;

    public Transform PlayerTransform { get { return _playerTransform; } }

    private void Start()
    {
        _gift = this.gameObject;
        _coinMoveScript = gameObject.GetComponent<CoinMove>();
    }

    private void Update()
    {
        _gift.transform.Rotate(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Action(other));      
            
        }

        if (other.CompareTag("CoinDetector"))
        {
            _playerTransform = other.GetComponentInChildren<MagnetScript>().PlayerTransform;
            _coinMoveScript.enabled = true;
        }
    }

    public override IEnumerator Action(Collider collider)
    {
        collider.GetComponent<ScoreSystem>().CatchUpPoint();
        collider.GetComponent<ScoreSystem>().GiftCounter();
        Destroy(this.gameObject);

        yield break;
    }
}
