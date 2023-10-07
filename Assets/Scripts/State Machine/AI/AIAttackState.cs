
using System.Collections;
using UnityEngine;

public class AIAttackState : AIState
{
    public bool cooldown = false;
    public int numCombo = 0;
    public int maxCombo = 3;
    public float lastClickTime = 0;
    private float force = 30f;

    public AIAttackState(Character character) : base(character)
    {
    }

    public override void EnterState(AIStateMachine aiState)
    {
        if (cooldown)
        {
            aiState.SwitchState(aiState.idleState);
            Debug.Log("cd");
        }
        else
        {
            Attack();
        }
    }

    public override void ExitState(AIStateMachine aiState)
    {
        if (numCombo > 0)
        {
            cooldown = true;
            aiState.cdAttack();
        }
        numCombo = 0;
    }

    public override void FrameUpdate(AIStateMachine aiState)
    {
        if (Time.time - lastClickTime > 1f)
        {
            aiState.SwitchState(aiState.idleState);
        }
    }

    public override void InputUpdate(AIStateMachine aiState)
    {
        if (character.isStun)
        {
            return;
        }

        if (Time.time - lastClickTime > character.timeStartAttack && numCombo <= maxCombo)
        {
            Attack();
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