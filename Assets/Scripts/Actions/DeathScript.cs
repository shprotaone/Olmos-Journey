using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour
{
    public delegate void Death();
    public static event Death OnDeath;
    
    [SerializeField] private GameObject _deathWindow;
    [SerializeField] private CurrentGameDataContainer _gameContainer;

    private void Start()
    {
        _gameContainer.death = false;
    }

    public void Action()
    {
        if(OnDeath != null)
        {
            _gameContainer.death = true;
            OnDeath();
            GetComponent<AudioSource>().Play();
        }
        
        StartCoroutine(ActivateDeathWindow());
    }

    private IEnumerator ActivateDeathWindow()
    {
        yield return new WaitForSeconds(1f);
        _deathWindow.SetActive(true);

        yield return null;
    }
}
