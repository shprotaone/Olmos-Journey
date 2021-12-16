using UnityEngine;

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
        }

        _worldController.StartMovement = false;
        _animator.SetBool(_deathAnim, true);
        _deathWindow.SetActive(true);
    }
}
