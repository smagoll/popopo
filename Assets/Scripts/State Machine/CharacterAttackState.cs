using UnityEngine;

public class CharacterAttackState : CharacterState
{
    public int numCombo = 0;
    public float lastClickTime = 0;
    public bool isEndCombo = false;

    public CharacterAttackState(Character character) : base(character)
    {
    }

    public override void AnimationTriggerEvent(CharacterStateMachine characterState)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(CharacterStateMachine characterState)
    {

    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        numCombo = 0;
        isEndCombo = false;
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {
        
        if (Time.time - lastClickTime > character.timeStartAttack && numCombo == 0)
        {
            lastClickTime = Time.time;
            numCombo++;
            character.animator.SetTrigger("attack" + numCombo);
        }

        if (isEndCombo)
        {
            characterState.SwitchState(characterState.idleState);
        }
    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {
        if (Input.GetKeyDown(characterState.input.attack))
        {
            lastClickTime = Time.time;
        }
    }
}

