using System;
using UnityEngine;
public class CharacterMovingState : CharacterState
{
    private Character character;

    public CharacterMovingState(Character character)
    {
        this.character = character;
    }


    public override void AnimationTriggerEvent(CharacterStateMachine characterState)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        Debug.Log("mov");
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        throw new System.NotImplementedException();
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {
        float axisValue = Input.GetAxis("Horizontal");
        character.Move(axisValue);

        if (Math.Abs(axisValue) == 0)
        {
            character.animator.SetBool("isRunning", false);
            characterState.SwitchState(characterState.idleState);
        }
    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {
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

