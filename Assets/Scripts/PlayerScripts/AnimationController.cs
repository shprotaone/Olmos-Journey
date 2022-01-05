using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{   
    [SerializeField] private Animator _animator;

    private int _leftAnimationID = Animator.StringToHash("Left");
    private int _rightAnimationID = Animator.StringToHash("Right");
    private int _startRunningAnimationID = Animator.StringToHash("StartRunning");
    private int _deathAnim = Animator.StringToHash("Death");
    private int _jumpAnimationID = Animator.StringToHash("Jump");

    public void AnimationLeft()
    {        
        if(_animator != null)
        _animator.SetTrigger(_leftAnimationID);
    }

    public void AnimationRight()
    {
        if (_animator != null)
            _animator.SetTrigger(_rightAnimationID);
    }

    public void AnimationStartRunning()
    {
        _animator.SetBool(_startRunningAnimationID, true);
    }

    public void AnimationDeath()
    {
        if (_animator != null)
            _animator.SetBool(_deathAnim, true);
    }

    public void JumpAnimation()
    {
        if (_animator != null)
            _animator.SetTrigger(_jumpAnimationID);
    }
}
