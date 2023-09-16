﻿using System;
using UnityEngine;
public class CharacterJumpState : CharacterState
{
    public CharacterJumpState(Character character) : base(character)
    {
    }

    public override void AnimationTriggerEvent(CharacterStateMachine characterState)
    {
        throw new NotImplementedException();
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        character.Jump();
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {
        characterState.SwitchState(characterState.idleState);
    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {

    }
}