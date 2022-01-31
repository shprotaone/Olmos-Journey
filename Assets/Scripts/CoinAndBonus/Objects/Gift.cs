using System.Collections;
using UnityEngine;

public class Gift : Bonus
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
            Action(other);
        }
        else if(other.CompareTag("Platform"))
        {
            StartCoroutine(DestroyGift());
        }
    }

    private void Action(Collider player)
    {
        StartCoroutine(DestroyAction(player));

        int index = Randomizer();
        player.GetComponent<InteractionWithSubject>().Gift(index);
        player.GetComponent<PlayerController>().CatchFirstGift();

        _effects[1].Play();
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
