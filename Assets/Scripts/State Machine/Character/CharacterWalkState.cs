using System;
using UnityEngine;
public class CharacterWalkState : CharacterState
{
    public CharacterWalkState(Character character) : base(character)
    {
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        character.animator.SetBool("isRunning", true);
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        character.animator.SetBool("isRunning", false);
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {
        float axisValue = Input.GetAxis("Horizontal");
        character.Move(axisValue);

        if (axisValue == 0)
        {
            characterState.SwitchState(characterState.idleState);
        }
    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {
        if ((Input.GetKeyDown(characterState.input.attack)))
        {
            characterState.attackState.isFirstAttack = true;
            characterState.SwitchState(characterState.attackState);
            return;
        }

        if ((Input.GetKeyDown(characterState.input.adittionalAttack)))
        {
            characterState.attackState.isFirstAttack = false;
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

