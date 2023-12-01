using UnityEngine;

public class CharacterAttackState : CharacterState
{
    public int numCombo = 0;
    public int maxCombo = 3;
    private float force = 30f;
    public float lastClickTime = 0;
    public bool isFirstAttack = true; //первая обычная атака

    private bool isDownAttack = false;

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

        if (Time.time - lastClickTime > character.stunAfterAttack)
        {
            characterState.SwitchState(characterState.idleState);
            return;
        }

        if (isDownAttack)
        {
            if (character.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && numCombo < character.attackController.maxCombo)
            {
                Attack();
                return;
            }
        }
        else
        {
            if (Input.GetKeyDown(characterState.input.attack))
            {
                isDownAttack = true;
                if (character.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && numCombo < character.attackController.maxCombo)
                {
                    Attack();
                    return;
                }
            }
        }

        if (Input.GetKeyDown(characterState.input.adittionalAttack))
        {
            if (Time.time - lastClickTime > character.timeStartAttack && numCombo < character.attackController.maxCombo)
            {
                AdAttack();
                return;
            }
        }
    }

    private void AdAttack()
    {
        character.animator.SetTrigger("ad_attack");
        character.rb.AddForce(character.GetDirectionToCloseEnemy() * force, ForceMode2D.Impulse);
        numCombo++;
        lastClickTime = Time.time;
    }
    
    private void Attack()
    {
        character.animator.SetTrigger("attack");
        character.rb.AddForce(character.GetDirectionToCloseEnemy() * force, ForceMode2D.Impulse);
        numCombo++;
        lastClickTime = Time.time;
        isDownAttack = false;
    }
}

