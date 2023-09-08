using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    float maxDelay = 0.2f;

    private CharacterStateMachine stateMachine;
    private void Start()
    {
        stateMachine = GetComponent<CharacterStateMachine>();
    }

    public void StartAttack2()
    {
        Debug.Log("start attack 2");
        if (Time.time - stateMachine.attackState.lastClickTime < maxDelay)
        {
            stateMachine.attackState.character.animator.SetTrigger("attack2");
        }
        else
        {
            stateMachine.SwitchState(stateMachine.idleState);
        }
    }
    
    public void StartAttack3()
    {
        Debug.Log("start attack 3");
        if (Time.time - stateMachine.attackState.lastClickTime < maxDelay)
        {
            stateMachine.attackState.character.animator.SetTrigger("attack3");
        }
        else
        {
            stateMachine.SwitchState(stateMachine.idleState);
        }
    }

    public void EndCombo()
    {
        stateMachine.SwitchState(stateMachine.idleState);
    }
}
