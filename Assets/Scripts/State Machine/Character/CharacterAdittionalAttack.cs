using UnityEngine;

public class CharacterAdittionalAttackState : CharacterState
{
    public int numCombo = 0;
    public int maxCombo = 3;
    public float lastClickTime = 0;
    private float force = 30f;

    public CharacterAdittionalAttackState(Character character) : base(character)
    {
    }

    public override void AnimationTriggerEvent(CharacterStateMachine characterState)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        Attack();
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        numCombo = 0;
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {
        if (Time.time - lastClickTime > 1f)
        {
            characterState.SwitchState(characterState.idleState);
        }
    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {
        if (Input.GetKeyDown(characterState.input.adittionalAttack))
        {
            if (Time.time - lastClickTime > character.timeStartAttack && numCombo < maxCombo)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        character.rb.AddForce(character.DirectionToCloseEnemy() * force, ForceMode2D.Impulse);
        lastClickTime = Time.time;
        numCombo++;
        character.animator.SetTrigger("ad_attack");
    }
}

