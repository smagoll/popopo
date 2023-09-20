using UnityEngine;

public class CharacterAttackState : CharacterState
{
    public int numCombo = 0;
    public int maxCombo = 3;
    public float lastClickTime = 0;
    public float maxClickTime = 1f;
    private float force = 30f;

    public CharacterAttackState(Character character) : base(character)
    {
    }

    public override void EnterState(CharacterStateMachine characterState)
    {
        Attack();
    }

    public override void ExitState(CharacterStateMachine characterState)
    {
        numCombo = 0;
        character.animator.SetTrigger("stopAttack");
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
        if (Input.GetKeyDown(characterState.input.attack))
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
        character.animator.SetTrigger("attack");
    }
}

