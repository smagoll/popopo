using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStunState : CharacterState
{
    public float startTime;

    public CharacterStunState(Character character) : base(character) { }

    public override void EnterState(CharacterStateMachine characterState)
    {
        startTime = Time.time;
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {
        
    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {
        if (Time.time - startTime > character.timeInStun)
        {
            characterState.SwitchState(characterState.idleState);
        }
    }
}
