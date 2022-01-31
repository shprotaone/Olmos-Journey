using System.Collections;
using UnityEngine;

public class Coin : Bonus
{
    [SerializeField] private Transform _playerTransform;
    private CoinMove _coinMoveScript;

    public Transform PlayerTransform { get { return _playerTransform; } }

    private void Start()
    {
        _coinMoveScript = gameObject.GetComponent<CoinMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DestroyAction(other));
            other.GetComponent<InteractionWithSubject>().AddCoin();
        }

        if (other.CompareTag("CoinDetector"))
        {
            _playerTransform = other.GetComponentInChildren<MagnetScript>().PlayerTransform;
            _coinMoveScript.enabled = true;
        }
    }
}
