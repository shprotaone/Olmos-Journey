using System.Collections;
using UnityEngine;

public class Coin : InterractableObject
{
    [SerializeField] private Transform _playerTransform;
    private CoinMove _coinMoveScript;
    private ParticleSystem _effect;

    public Transform PlayerTransform { get { return _playerTransform; } }

    private void Start()
    {
        _coinMoveScript = gameObject.GetComponent<CoinMove>();
        _effect = GetComponentInChildren<ParticleSystem>();
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

        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        
        GetComponent<AudioSource>().Play();
        _effect.Play();      

        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

        yield break;
    }
}
