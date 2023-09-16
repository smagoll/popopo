﻿using System;
using UnityEngine;

public class CharacterIdleState : CharacterState
{
    public CharacterIdleState(Character character) : base(character)
    {
    }

    public override void AnimationTriggerEvent(CharacterStateMachine characterState)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        Debug.Log("idle");
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        
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

        if (Math.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            characterState.SwitchState(characterState.walkState);
        }

        if ((Input.GetKeyDown(characterState.input.adittionalAttack)))
        {
            characterState.SwitchState(characterState.adittionalAttackState);
        }
        
        if ((Input.GetKeyDown(characterState.input.attack)))
        {
            characterState.SwitchState(characterState.attackState);
        }

        if (Input.GetKeyDown(characterState.input.up))
        {
            characterState.SwitchState(characterState.jumpState);
        }

        if (Input.GetKeyDown(characterState.input.block))
        {
            characterState.SwitchState(characterState.blockState);
        }

        if (Input.GetKeyDown(characterState.input.down))
        {
            characterState.SwitchState(characterState.duckState);
        }
    }
}
