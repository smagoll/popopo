using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBlockState : AIState
{
    private int chance = 50;
    private float lastUnluckyBlock = 0f;

    public AIBlockState(Character character) : base(character) { }

    public override void EnterState(AIStateMachine aiState)
    {
        if (Time.time - lastUnluckyBlock > 0.5f)
        {
            var number = Random.Range(0, 100);
            if (number < chance)
            {
                character.animator.SetBool("block", true);
                character.isBlock = true;
                return;
            }
            else
            {
                lastUnluckyBlock = Time.time;
            }
        }
        aiState.SwitchState(aiState.idleState);
    }

    public override void ExitState(AIStateMachine aiState)
    {
        if (character.isBlock)
        {
            character.animator.SetBool("block", false);
            character.isBlock = false;
        }
    }

    public override void FrameUpdate(AIStateMachine aiState)
    {
        
    }

    public override void InputUpdate(AIStateMachine aiState)
    {
        var enemy = character.GetCloseEnemy();
        if (enemy.GetComponent<Character>().isAttack == false)
        {
            aiState.SwitchState(aiState.idleState);
        }
    }
}
