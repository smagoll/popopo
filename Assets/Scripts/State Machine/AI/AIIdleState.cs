using System;
using UnityEngine;

public class AIIdleState : AIState
{
    public AIIdleState(Character character) : base(character)
    {
    }

    public override void EnterState(AIStateMachine aiState)
    {
        
    }

    public override void ExitState(AIStateMachine aiState)
    {
        
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

        if (distance > character.distanceStates.distanceSkill)
        {
            aiState.SwitchState(aiState.skillState);
            return;
        }
        
        if (distance < character.distanceStates.distanceAttack)
        {
            aiState.SwitchState(aiState.attackState);
            return;
        }
        
        if (distance > character.distanceStates.distanceAttack)
        {
            aiState.SwitchState(aiState.walkState);
            return;
        }
    }
}

