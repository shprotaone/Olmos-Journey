using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : InterractableObject
{
    private ParticleSystem _explosion;

    private void Start()
    {
        _explosion = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!other.GetComponent<PlayerController>().PlayerDeath)
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
        print(index);
        Destroy(this.gameObject);
        
        yield break;
    }

    private IEnumerator DestroyGift()
    {
        _explosion.Play();
        yield return new WaitForSeconds(0.5f);

        Destroy(this.gameObject);

        yield break;
    }
    private int Randomizer()
    {
        int result = Random.Range(0, 3);
        return result;
    }
}
