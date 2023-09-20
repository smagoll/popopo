using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDuckState : CharacterState
{
    public CharacterDuckState(Character character) : base(character)
    {
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        character.animator.SetBool("isDuck", true);
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        character.animator.SetBool("isDuck", false);
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {

    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {
        if (Input.GetKeyUp(characterState.input.down))
        {
            characterState.SwitchState(characterState.idleState);
        }
    }
}
