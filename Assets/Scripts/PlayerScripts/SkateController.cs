using UnityEngine;
using System.Collections;

public class SkateController : MonoBehaviour
{
    [SerializeField] private AudioClip _rotateSound;
    [SerializeField] private CurrentGameDataContainer _gameContainer;
    [SerializeField] private WorldController _worldController;

    private ParticleSystem _slideFX;

    private AudioSource _audioSource;
    private float _turnVolume = 0.2f;
    private float _reductionParticleSpeed = 2;
    private float _startVolume;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _slideFX = GetComponentInChildren<ParticleSystem>();
        _startVolume = _audioSource.volume;
        HealthSystem.OnDeath += Death;
    }

    private void Update()
    {
        ParticleSpeedController();
    }

    public void TurnSound()
    {
        if (_audioSource != null)
            _audioSource.PlayOneShot(_rotateSound, _turnVolume);
    }

    public void SlideActions(bool value)
    {
        if (_audioSource != null)
        {
            if (!_audioSource.isPlaying && !_gameContainer.gameInPaused)
            {
                _audioSource.Play();

            }
            else if (_gameContainer.gameInPaused)
            {
                _audioSource.Stop();
                _slideFX.Stop();
            }
            else if (value)
            {
                _audioSource.volume = _startVolume;

                if (!_slideFX.isPlaying)
                    _slideFX.Play();
            }
            else if (!value)
            {
                StartCoroutine(FadeSound());
                _slideFX.Stop();
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


        yield break;
    }

    private void ParticleSpeedController()
    {
        var main = _slideFX.main;
        main.startSpeed = _worldController.CurrentSpeed / _reductionParticleSpeed;
    }

    private void Death()
    {
        if (_audioSource != null)
        {
            _audioSource.Stop();
            _slideFX.Stop();
        }
    }

    private void OnDestroy()
    {
        HealthSystem.OnDeath -= Death;
    }
}
