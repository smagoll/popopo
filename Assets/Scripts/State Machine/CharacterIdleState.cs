using System;
using UnityEngine;

public class CharacterIdleState : CharacterState
{
    private Character character;

    public CharacterIdleState(Character character)
    {
        this.character = character;
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
        throw new System.NotImplementedException();
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {
        
    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {
        if (Math.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            character.animator.SetBool("isRunning", true);
            characterState.SwitchState(characterState.movingState);
        }

        if (character.Attack(Input.GetKeyDown(KeyCode.H)))
        {
            characterState.SwitchState(characterState.attackState);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            characterState.SwitchState(characterState.jumpState);
        }

    }
}

