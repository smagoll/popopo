using UnityEngine;
public class CharacterStateMachine : MonoBehaviour
{
    private Character character;

    private CharacterState currentState;
    public CharacterWalkState walkState;
    public CharacterIdleState idleState;
    public CharacterAttackState attackState;
    public CharacterAdittionalAttackState adittionalAttackState;
    public CharacterJumpState jumpState;
    public CharacterBlockState blockState;
    public CharacterDuckState duckState;

    public InputAsset input;

    private void Awake()
    {
        character = gameObject.GetComponent<Character>();

        walkState = new(character);
        idleState = new(character);
        attackState = new(character);
        adittionalAttackState = new(character);
        jumpState = new(character);
        blockState = new(character);
        duckState = new(character);

        currentState = idleState;
    }

    private void Start()
    {
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.InputUpdate(this);
        currentState.FrameUpdate(this);
    }

    public void SwitchState(CharacterState state)
    {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }
}
