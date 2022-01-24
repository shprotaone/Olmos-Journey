using System.Collections;
using UnityEngine;

public class Gift : InterractableObject
{
    private ParticleSystem[] _effects;  //0 - DestroyExplosion, 1 - Catch

    [SerializeField] private AudioClip [] _sounds; //0 - Coin,1 - magnetSound,2 - Coin

    private AudioSource _source;
    private void Start()
    {
        _effects = GetComponentsInChildren<ParticleSystem>();
        _source = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Action(other));
        }
        else if(other.CompareTag("Platform"))
        {
            StartCoroutine(DestroyGift());
        }
    }

    public override IEnumerator Action(Collider collider)
    {
        int index = Randomizer();
        collider.GetComponent<InteractionWithSubject>().Gift(index);
        collider.GetComponent<PlayerController>().CatchFirstGift();

        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;

        _source.PlayOneShot(_sounds[index]);
        _effects[1].Play();

        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        
        yield break;
    }

    private IEnumerator DestroyGift()
    {
        _effects[0].Play();
        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);

        yield break;
    }
    private int Randomizer()
    {
        int result = Random.Range(0, 3);
        return result;
    }
}
