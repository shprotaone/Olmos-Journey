using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyScore : InterractableObject
{
    private ParticleSystem _effect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _effect = GetComponentInChildren<ParticleSystem>();
            StartCoroutine(Action(other));
        }
    }

    public override IEnumerator Action(Collider collider)
    {
        collider.GetComponent<InteractionWithSubject>().MultiplyCoin();
        GetComponent<AudioSource>().Play();

        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        _effect.Play();

        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

        yield break;
    }
}
