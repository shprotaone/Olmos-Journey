﻿using UnityEngine;

public class StartRunningScript : MonoBehaviour, IAction
{
    [SerializeField] private WorldController _worldController;
    [SerializeField] private GameObject _guide;
    private Animator _animator;

    private int _startRunAnim;
    private bool _isStarted;

    public bool IsStarted { get { return _isStarted; } }

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _startRunAnim = Animator.StringToHash("StartRunning");
    }

    public void Action(bool triggered)
    {
        _isStarted = triggered;
        _animator.SetBool(_startRunAnim,true);
        _worldController.StartMovement = true;
        //_guide.SetActive(false);
    }
}