using System;
using UnityEngine;

public class CharacterAttackState : CharacterState
{
    private Character character;
    public CharacterAttackState(Character character)
    {
        this.character = character;
    }

    public override void AnimationTriggerEvent(CharacterStateMachine characterState)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        Debug.Log("attack");
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        throw new System.NotImplementedException();
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {
        characterState.SwitchState(characterState.idleState);
    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {
        
    }
}

