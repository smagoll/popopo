using UnityEngine;

public class CharacterAttackState : CharacterState
{
    public int numCombo = 0;
    public int maxCombo = 3;
    private float force = 30f;
    public bool isFirstAttack = true; //первая обычная атака

    public CharacterAttackState(Character character) : base(character)
    {
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        if (isFirstAttack)
            Attack();
        else
            AdAttack();
        character.isAttack = true;
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        numCombo = 0;
        character.animator.SetTrigger("stopAttack");
        character.isAttack = false;
    }

    public override void FrameUpdate(CharacterStateMachine characterState)
    {

    }

    public override void InputUpdate(CharacterStateMachine characterState)
    {

        if (character.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > character.stunAfterAttack)
        {
            characterState.SwitchState(characterState.idleState);
            return;
        }

        if (Input.GetKeyDown(characterState.input.attack))
        {
            if (character.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > character.timeStartAttack && numCombo < maxCombo)
            {
                Attack();
                return;
            }
        }

        if (Input.GetKeyDown(characterState.input.adittionalAttack))
        {
            if (character.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > character.timeStartAttack && numCombo < maxCombo)
            {
                AdAttack();
                return;
            }
        }
    }

    private void Attack()
    {
        character.rb.AddForce(character.GetDirectionToCloseEnemy() * force, ForceMode2D.Impulse);
        numCombo++;
        character.animator.SetTrigger("attack");
    }

    private void AdAttack()
    {
        character.rb.AddForce(character.GetDirectionToCloseEnemy() * force, ForceMode2D.Impulse);
        numCombo++;
        character.animator.SetTrigger("ad_attack");
    }
}

