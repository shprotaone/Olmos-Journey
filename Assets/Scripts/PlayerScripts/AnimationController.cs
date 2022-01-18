using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{   
    [SerializeField] private Animator _animator;

    private int _leftAnimationID = Animator.StringToHash("Left");
    private int _rightAnimationID = Animator.StringToHash("Right");
    private int _startRunningAnimationID = Animator.StringToHash("StartRunning");
    private int _deathAnimationID = Animator.StringToHash("Death");
    private int _jumpAnimationID = Animator.StringToHash("Jump");
    private int _damageAnimationID = Animator.StringToHash("Damage");
    private int _glideAnimationID = Animator.StringToHash("Glide");

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
            _animator.SetBool(_deathAnimationID, true);
    }

    public void JumpAnimation()
    {
        if (_animator != null)
            _animator.SetTrigger(_jumpAnimationID);
    }

    public void DamageAnimation()
    {
        if(_animator != null)
        _animator.SetBool(_damageAnimationID,true);
    }

    public void Glide(bool state)
    {
        if(_animator != null)
        {
            _animator.SetBool(_glideAnimationID,state);
        }
    }
}
