﻿
using UnityEngine;

public class CharacterBlockState : CharacterState
{
    public CharacterBlockState(Character character) : base(character)
    {
    }

    public override void AnimationTriggerEvent(CharacterStateMachine characterState)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        character.animator.SetTrigger("block");
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        character.animator.SetTrigger("block");
        character.ExitBlock();
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {
        
    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {
        if (character.isStun)
        {
            return;
        }

        if (Input.GetKeyUp(characterState.input.block))
        {
            characterState.SwitchState(characterState.idleState);
        }
    }
}