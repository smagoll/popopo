using System;
using UnityEngine;

public class CharacterIdleState : CharacterState
{
    public CharacterIdleState(Character character) : base(character)
    {
    }

    public override void EnterState(CharacterStateMachine characterState)
    {

    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {
        
    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {
        if (Math.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            characterState.SwitchState(characterState.walkState);
            return;
        }

        if ((Input.GetKeyDown(characterState.input.adittionalAttack)))
        {
            characterState.attackState.isFirstAttack = false;
            characterState.SwitchState(characterState.attackState);
            return;
        }

        if ((Input.GetKeyDown(characterState.input.attack)))
        {
            characterState.attackState.isFirstAttack = true;
            characterState.SwitchState(characterState.attackState);
            return;
        }

        if (Input.GetKeyDown(characterState.input.up))
        {
            characterState.SwitchState(characterState.jumpState);
            return;
        }

        if (Input.GetKey(characterState.input.block))
        {
            characterState.SwitchState(characterState.blockState);
            return;
        }

        if (Input.GetKey(characterState.input.down))
        {
            characterState.SwitchState(characterState.duckState);
            return;
        }
        
        if (Input.GetKey(characterState.input.skill))
        {
            characterState.SwitchState(characterState.skillState);
            return;
        }
    }
}

