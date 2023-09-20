public abstract class CharacterState
{
    public Character character;

    public CharacterState(Character character)
    {
        this.character = character;
    }
    public abstract void EnterState(CharacterStateMachine characterState);
    public abstract void ExitState(CharacterStateMachine characterState);
    public abstract void FrameUpdate(CharacterStateMachine characterState);
    public abstract void InputUpdate(CharacterStateMachine characterState);
}
