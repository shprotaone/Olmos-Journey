using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    [SerializeField] private GameObject _coinDetector;
    [SerializeField] private BonusDisplay _bonusDisplay;
    [SerializeField] private Sprite _magnetSprite;
    [SerializeField] private float _activeTime; 

    private AudioSource _audioSource;
    private bool _isActivated;
    public Transform PlayerTransform { get; private set; }

    void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayerTransform = GetComponentInParent<Transform>();
    }

    public void EnableController()
    {
        _coinDetector.SetActive(true);
        print("MagnetActivated");

        if (!_isActivated)
        {
            _isActivated = true;
            StartCoroutine(MagnetActivate());
        }
        else
        {
            StopCoroutine(MagnetActivate());
            _isActivated = true;
            StartCoroutine(MagnetActivate());
        }
    }

   public IEnumerator MagnetActivate()
    {
        _bonusDisplay.BonusOn(_activeTime,_magnetSprite);        

        if(_audioSource != null)
        _audioSource.Play();

        yield return new WaitForSeconds(_activeTime);

        _audioSource.Stop();
        _coinDetector.SetActive(false);
        print("MagnetDesactivated");
        _isActivated = false;

        yield break;
    }

    //в будущем добавить наложение при сборе 2х бонусов Магнита

}
