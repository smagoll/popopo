using UnityEngine;

public class CharacterAttackState : CharacterState
{
    public int numCombo = 0;
    public int maxCombo = 3;
    public float lastClickTime = 0;
    private float force = 30f;

    public CharacterAttackState(Character character) : base(character)
    {
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        Attack();
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

        if (Input.GetKeyDown(characterState.input.attack))
        {
            if (Time.time - lastClickTime > character.timeStartAttack && numCombo < maxCombo)
            {
                Attack();
                return;
            }
        }
    }

    private void Attack()
    {
        character.rb.AddForce(character.GetDirectionToCloseEnemy() * force, ForceMode2D.Impulse);
        lastClickTime = Time.time;
        numCombo++;
        character.animator.SetTrigger("attack");
    }
}

