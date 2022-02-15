using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    protected PlayerController _controller;
    protected StateMachine _stateMachine;

    protected State(PlayerController playerController, StateMachine stateMachine)
    {
        this._controller =playerController;
        this._stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual string OutputName() { return " "; }

}
