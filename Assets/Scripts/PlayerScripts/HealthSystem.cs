using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public delegate void Death();
    public static event Death OnDeath;

    [SerializeField] private GameObject[] _heartUI;
    [SerializeField] private GameObject[] _deathWindows;    //0 - secondChance, 1 - Result
    [SerializeField] private SpriteRenderer[] _playerSprite;
    [SerializeField] private CurrentGameDataContainer _gameContainer;
    [SerializeField] private WorldController _worldController;

    private AnimationController _animController;
    private int _health = 3;
    private int _changeSpeed = -3;

    private bool _secondChance = true;

    private void Start()
    {
        _gameContainer.death = false;
        _animController = GetComponent<AnimationController>();
    }

    public void DeathMeth()
    {
        if (OnDeath != null)
        {
            _health = 0;

            _gameContainer.death = true;
            _animController.AnimationDeath(true);

            OnDeath();
            GetComponent<AudioSource>().Play();
        }

        StartCoroutine(ActivateDeathWindow());
    }

    private IEnumerator ActivateDeathWindow()
    {
        if (_secondChance)
        {
            yield return new WaitForSeconds(1f);
            _deathWindows[0].SetActive(true);

            _secondChance = false;
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(1f);
            _deathWindows[1].SetActive(true);

            yield return null;
        }
    }

    private void RefreshUI(int health)
    {
        _heartUI[_health].SetActive(false);
    }

    /// <summary>
    /// подтверждение урона
    /// </summary>
    /// <param name="isFastDeath">ставим true, если смерть мгновенная</param>
    public void ApplyDamage(bool isQuickDeath)       //переделать
    {
        if (isQuickDeath)
        {
            for (int i = 0; i < _health;)
            {
                _health -= 1;
                RefreshUI(_health);
            }
        }
        else 
        {
            _health -= 1;
            RefreshUI(_health);
        }
        
         _animController.DamageAnimation();

        DeathCheked();

        StartCoroutine(_worldController.SpeedChanger(_changeSpeed));
    }

    public void DeathCheked()
    {
        if (_health == 0)
        {
            DeathMeth();
        }
    }

    public void QuickDeath()
    {
        ApplyDamage(true);
        _animController.Glide(false);

        DeathCheked();
    }

    public void ResetHealth()
    {
        _health = 3;

        foreach (var item in _heartUI)
        {
            if(item!=null)
            item.SetActive(true);
        }   
    }
}
