using System;
using UnityEngine;

public class AIWalkState : AIState
{
    private float distanceAttack = 3f;

    public AIWalkState(Character character) : base(character)
    {
    }

    public override void EnterState(AIStateMachine aiState)
    {
        character.animator.SetBool("isRunning", true);
    }

    public override void ExitState(AIStateMachine aiState)
    {
        character.animator.SetBool("isRunning", false);
    }

    public override void FrameUpdate(AIStateMachine aiState)
    {
        var distance = character.GetDistanceToCloseEnemy();
        if (distance < distanceAttack)
        {
            aiState.SwitchState(aiState.idleState);
        }
        else
        {
            character.Move(character.GetDirectionToCloseEnemy().x);
        }
    }

    public override void InputUpdate(AIStateMachine aiState)
    {
        
    }
}

