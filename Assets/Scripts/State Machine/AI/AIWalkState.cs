using System;
using UnityEngine;

public class AIWalkState : AIState
{
    private float distanceAttack = 3f;

    public AIWalkState(Character character) : base(character) { }

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

    }

    public override void InputUpdate(AIStateMachine aiState)
    {
        var distance = character.GetDistanceToCloseEnemy();
        var enemy = character.GetCloseEnemy();

        character.UseAbilities();

        if (enemy.GetComponent<Character>().isAttack && distance < character.distanceStates.distanceBlock)
        {
            aiState.SwitchState(aiState.blockState);
            return;
        }

        if (distance < distanceAttack)
        {
            aiState.SwitchState(aiState.idleState);
            return;
        }
        else
        {
            character.Move(character.GetDirectionToCloseEnemy().x);
            return;
        }
    }
}

