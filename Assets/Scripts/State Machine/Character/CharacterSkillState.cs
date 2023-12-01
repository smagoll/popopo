using System.Collections;
using UnityEngine;

public class CharacterSkillState : CharacterState
{
    private float speedRegen = 0.02f;

    public CharacterSkillState(Character character) : base(character) { }

    public override void EnterState(CharacterStateMachine characterState)
    {
        character.animator.SetBool("skill", true);
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        character.animator.SetBool("skill", false);
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {
        Regen();
    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {
        if (Input.GetKeyUp(characterState.input.skill))
        {
            characterState.SwitchState(characterState.idleState);
        }
    }

    private void Regen()
    {
        character.Mp += speedRegen;
    }
}
