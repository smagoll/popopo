using UnityEngine;

public class CharacterAdittionalAttackState : CharacterState
{
    public CharacterAdittionalAttackState(Character character) : base(character)
    {
    }

    public override void AnimationTriggerEvent(CharacterStateMachine characterState)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        Debug.Log("ad attack");
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

