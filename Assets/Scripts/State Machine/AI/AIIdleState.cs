using System;
using UnityEngine;

public class AIIdleState : AIState
{
    private float distanceAttack = 3f;

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
        var distance = character.DistanceToCloseEnemy();
        if (distance > distanceAttack)
        {
            aiState.SwitchState(aiState.walkState);
        }
        else
        {
            aiState.SwitchState(aiState.attackState);
        }
    }

    public override void InputUpdate(AIStateMachine characterState)
    {

    }
}

