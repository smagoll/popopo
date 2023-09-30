using System;
using UnityEngine;

public class AIIdleState : AIState
{
    public AIIdleState(Character character) : base(character)
    {
    }

    public override void EnterState(AIStateMachine aiState)
    {
        Debug.Log("idle ai");
    }

    public override void ExitState(AIStateMachine aiState)
    {
        
    }

    public override void FrameUpdate(AIStateMachine aiState)
    {

    }

    public override void InputUpdate(AIStateMachine characterState)
    {

    }
}

