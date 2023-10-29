
using UnityEngine;

public class CharacterBlockState : CharacterState
{
    public CharacterBlockState(Character character) : base(character)
    {
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        character.animator.SetTrigger("block");
        character.isBlock = true;
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        character.animator.SetTrigger("block");
        character.isBlock = false;
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {
        
    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {
        if (Input.GetKeyUp(characterState.input.block))
        {
            characterState.SwitchState(characterState.idleState);
        }
    }
}
