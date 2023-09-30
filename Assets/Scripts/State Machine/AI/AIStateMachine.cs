using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    private float distanceAttack = 3f;
    private float distanceSkill = 7f;

    private float cooldownAttack = 2f;

    private Character character;

    private AIState currentState;
    public AIIdleState idleState;
    public AIWalkState walkState;
    public AIAttackState attackState;
    public AISkillState skillState;

    private void Awake()
    {
        character = gameObject.GetComponent<Character>();

        idleState = new(character);
        walkState = new(character);
        attackState = new(character);
        skillState = new(character);

        currentState = idleState;
    }
    private void Start()
    {
        currentState.EnterState(this);
    }

    private void Update()
    {
        if (character.isStun)
        {
            return;
        }
        CheckDistance();
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

    public void cdAttack()
    {
        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(cooldownAttack);
        attackState.cooldown = false;
    }

    private void CheckDistance()
    {
        var distance = character.DistanceToCloseEnemy();
        if (distance > distanceSkill)
        {
            if (currentState != skillState)
            {
                SwitchState(skillState);
            }
            return;
        }

        if (distance < distanceAttack)
        {
            if (currentState != attackState)
            {
                SwitchState(attackState);
            }
            return;
        }

        if (distance > distanceAttack)
        {
            if (currentState != walkState)
            {
                SwitchState(walkState);
            }
            return;
        }
    }
}
