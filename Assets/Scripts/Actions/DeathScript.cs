using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour, IAction
{
    public delegate void Death();
    public static event Death OnDeath;
    
    [SerializeField] private WorldController _worldController;
    [SerializeField] private GameObject _deathWindow;

    private Animator _animator;
    private int _deathAnim = Animator.StringToHash("Death");

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Action()
    {
        if(OnDeath != null)
        {
            OnDeath();
            GetComponent<AudioSource>().Play();
        }

        _worldController.StartMovement = false;
        _animator.SetBool(_deathAnim, true);
        StartCoroutine(ActivateDeathWindow());
    }

    private IEnumerator ActivateDeathWindow()
    {
        yield return new WaitForSeconds(1f);
        _deathWindow.SetActive(true);

        yield return null;
    }
}
