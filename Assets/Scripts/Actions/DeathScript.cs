using UnityEngine;

public class DeathScript : MonoBehaviour, IAction
{
    [SerializeField] private WorldController _worldController;

    private Animator _animator;
    private int _deathAnim = Animator.StringToHash("Death");

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Action(bool triggered)
    {
        _worldController.StartMovement = false;
        _animator.SetBool(_deathAnim, true);
    }
}
