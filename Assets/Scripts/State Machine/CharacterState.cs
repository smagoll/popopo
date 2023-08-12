using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterState
{
    public abstract void EnterState(CharacterStateMachine character);
    public abstract void ExitState(CharacterStateMachine character);
    public abstract void FrameUpdate(CharacterStateMachine character);
    public abstract void InputUpdate(CharacterStateMachine character);
    public abstract void AnimationTriggerEvent(CharacterStateMachine character);
}
