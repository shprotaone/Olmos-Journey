using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override string OutputName()
    {
        return base.OutputName();
    }
}
