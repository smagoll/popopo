using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    private Character character;

    private AIState currentState;
    public AIIdleState idleState;
    public AIWalkState walkState;
    public AIAttackState attackState;

    private void Awake()
    {
        character = gameObject.GetComponent<Character>();

        idleState = new(character);
        walkState = new(character);
        attackState = new(character);

        currentState = idleState;
    }
    void Start()
    {
        currentState.EnterState(this);
    }

    void Update()
    {
        if (character.isStun)
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
}
