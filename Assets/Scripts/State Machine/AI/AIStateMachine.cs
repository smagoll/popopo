using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{

    private float cooldownAttack = 2f;

    private Character character;

    private AIState currentState;
    public AIIdleState idleState;
    public AIWalkState walkState;
    public AIAttackState attackState;
    public AISkillState skillState;
    public AIBlockState blockState;
    public AIStunState stunState;

    private void Awake()
    {
        character = gameObject.GetComponent<Character>();

        idleState = new(character);
        walkState = new(character);
        attackState = new(character);
        skillState = new(character);
        blockState = new(character);
        stunState = new(character);

        currentState = idleState;
    }
    private void Start()
    {
        currentState.EnterState(this);
    }

    private void Update()
    {
        if (character.isDead || character.isStun || character.useAbility)
        {
            return;
        }

        currentState.InputUpdate(this);
        currentState.FrameUpdate(this);
    }

    public void SwitchState(AIState state)
    {
        currentState.ExitState(this);
        character.FlipToEnemy();
        currentState = state;
        state.EnterState(this);
    }

    public void CooldownAttack()
    {
        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        attackState.cooldown = true;
        yield return new WaitForSeconds(cooldownAttack);
        attackState.cooldown = false;
    }

    public void OnHurt()
    {
        if (currentState == stunState)
        {
            stunState.startTime = Time.time;
        }
        else
        {
            SwitchState(stunState);
        } 
    }
}
