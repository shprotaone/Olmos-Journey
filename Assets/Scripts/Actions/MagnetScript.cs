using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    private const int indexDisplay = 0;

    [SerializeField] private GameObject _coinDetector;
    [SerializeField] private BonusDisplay _bonusDisplay;
    [SerializeField] private Sprite _magnetSprite;
    private float _activeTime;

    private AudioSource _audioSource;
    private bool _isActivated;
    
    public Transform PlayerTransform { get; private set; }

    void OnEnable()
    {       
        _audioSource = GetComponent<AudioSource>();
        PlayerTransform = GetComponentInParent<Transform>();
    }

    public void EnableMagnet()
    {
        _coinDetector.SetActive(true);

        if (!_isActivated)
        {
            _isActivated = true;
            StartCoroutine(MagnetActivate());
        }
        else
        {
            StopCoroutine(MagnetActivate());
            _bonusDisplay.ResetView(indexDisplay);
            _isActivated = false;
            StartCoroutine(MagnetActivate());
            _isActivated = true;
        }
    }

   public IEnumerator MagnetActivate()
    {
        _activeTime = 11;
        float perTime = 1f;
        _bonusDisplay.BonusOn(indexDisplay,_activeTime,_magnetSprite);

        if (_audioSource != null)
        {
            _audioSource.Play();
        }
       
        while (_activeTime > 0)
        {
            _activeTime -= perTime;
            yield return new WaitForSeconds(1f);
        }
        _isActivated = false;

        _coinDetector.SetActive(false);
        _audioSource.Stop();
        

        yield break;
    }
}
