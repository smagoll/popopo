using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStunState : AIState
{
    public float startTime;

    public AIStunState(Character character) : base(character) { }

    public override void EnterState(AIStateMachine aiState)
    {
        Debug.Log("enter stun");
        startTime = Time.time;
    }

    public override void ExitState(AIStateMachine aiState)
    {
        Debug.Log("exit stun");
    }

    public override void FrameUpdate(AIStateMachine aiState)
    {
        
    }

    public override void InputUpdate(AIStateMachine aiState)
    {
        if (Time.time - startTime > character.timeInStun)
        {
            aiState.SwitchState(aiState.idleState);
        }
    }
}
