using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISkillState : AIState
{
    private float speedRegen = 0.02f;

    public AISkillState(Character character) : base(character)
    {

    }

    public override void EnterState(AIStateMachine aiState)
    {
        
    }

    public override void ExitState(AIStateMachine aiState)
    {
        
    }

    public override void FrameUpdate(AIStateMachine aiState)
    {
        Regen();
    }

    public override void InputUpdate(AIStateMachine aiState)
    {
        if (character.Mp == character.maxMp)
        {
            aiState.SwitchState(aiState.idleState);
        }
    }

    private void Regen()
    {
        character.Mp += speedRegen;
    }
}
