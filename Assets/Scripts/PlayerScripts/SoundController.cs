using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _rotateSound;
    [SerializeField] private CommonScoreContainer _gameContainer;

    private AudioSource _audioSource;
    private float _turnVolume = 0.2f;
    private float _startVolume;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _startVolume = _audioSource.volume;
        DeathScript.OnDeath += Death;
    }

    public void TurnSound()
    {
        if(_audioSource != null)
        _audioSource.PlayOneShot(_rotateSound, _turnVolume);
    }

    public void SlideSound(bool value)
    {
        if(_audioSource != null)
        {
            if (!_gameContainer.paused)
            {
                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                }
                else if (value)
                {
                    _audioSource.volume = _startVolume;
                }
                else if (!value)
                {
                    StartCoroutine(FadeSound());
                    StopCoroutine(FadeSound());
                }
            }
            else
            {
                _audioSource.Stop();
            }    
        }
    }

    private IEnumerator FadeSound()
    {
        float fadeTime = 0.5f;

        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= _startVolume * Time.deltaTime / fadeTime;
            yield return new WaitForSeconds(1f);
        }

        yield return null;
    }

    private void Death()
    {
        if (_audioSource != null)
        {
            _audioSource.Stop();
        }
    }
}
