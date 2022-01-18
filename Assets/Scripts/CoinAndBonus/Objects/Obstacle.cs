using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ParticleSystem _effect;
    private SpriteRenderer _renderer;
    private AudioSource _audioSource;

    private void Start()
    {
        _effect = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Action(other));
        }
    }

    private IEnumerator Action(Collider other)
    {
        GetDamage(other);
        EffectActivate(other);

        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);

        yield break;
    }

    protected void GetDamage(Collider other)
    {
        other.GetComponent<HealthSystem>().ApplyDamage(false);
    }

    protected void EffectActivate(Collider other)
    {
        _renderer = this.gameObject.GetComponent<SpriteRenderer>();     //переделать через абстрактный класс(базовый класс Obstacle)
        _audioSource = GetComponent<AudioSource>();

        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        if(_renderer != null)
        _renderer.enabled = false;

        if(_effect!= null)
        _effect.Play();

        if(_audioSource != null)
        _audioSource.Play();
    }
}
