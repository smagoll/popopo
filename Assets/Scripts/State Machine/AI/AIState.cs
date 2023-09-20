public abstract class AIState
{
    public Character character;

    public AIState(Character character)
    {
        this.character = character;
    }
    public abstract void EnterState(AIStateMachine aiState);
    public abstract void ExitState(AIStateMachine aiState);
    public abstract void FrameUpdate(AIStateMachine aiState);
    public abstract void InputUpdate(AIStateMachine aiState);
}
