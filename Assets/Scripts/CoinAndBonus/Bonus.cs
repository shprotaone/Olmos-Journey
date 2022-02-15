using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private AudioSource _audioSource;
    private ParticleSystem _particleSystem;

    private BoxCollider _boxCollider;
    private SpriteRenderer[] _sprites;

    private void Init()
    {
        _audioSource = GetComponent<AudioSource>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _boxCollider = GetComponent<BoxCollider>();
        _sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    protected IEnumerator DestroyAction(Collider collider)
    {
        Init();

        _boxCollider.enabled = false;

        foreach (var sprite in _sprites)
        {
            sprite.enabled = false;
        }

        if (_audioSource != null)
            _audioSource.Play();

        if(_particleSystem != null)
            _particleSystem.Play();

        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

        yield break;
    }
}
