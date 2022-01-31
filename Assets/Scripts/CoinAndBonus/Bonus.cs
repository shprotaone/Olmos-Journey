using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private AudioSource _audioSource;
    private ParticleSystem _particleSystem;

    protected IEnumerator DestroyAction(Collider collider)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;

        this._audioSource = GetComponent<AudioSource>();
        this._particleSystem = GetComponentInChildren<ParticleSystem>();

        if (_audioSource != null)
            _audioSource.Play();

        if(_particleSystem != null)
            _particleSystem.Play();

        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

        yield break;
    }
}
