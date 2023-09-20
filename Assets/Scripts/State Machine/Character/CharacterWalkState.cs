using System;
using UnityEngine;
public class CharacterWalkState : CharacterState
{
    public CharacterWalkState(Character character) : base(character)
    {
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        Debug.Log("mov");
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
            characterState.SwitchState(characterState.attackState);
        }

        if ((Input.GetKeyDown(characterState.input.adittionalAttack)))
        {
            characterState.SwitchState(characterState.adittionalAttackState);
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

        if (Input.GetKeyDown(characterState.input.skill))
        {
            characterState.SwitchState(characterState.skillState);
        }
    }
}

