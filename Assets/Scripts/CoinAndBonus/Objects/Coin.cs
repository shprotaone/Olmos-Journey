using System.Collections;
using UnityEngine;

public class Coin : InterractableObject
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
        collider.GetComponent<InteractionWithSubject>().AddCoin();
        Destroy(this.gameObject);

        yield break;
    }
}
