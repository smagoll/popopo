using UnityEngine;
public class CharacterStateMachine : MonoBehaviour
{
    [SerializeField]
    private Character character;

    private CharacterState currentState;
    public CharacterMovingState movingState;
    public CharacterIdleState idleState;
    public CharacterAttackState attackState;
    public CharacterJumpState jumpState;

    private void Awake()
    {
        movingState = new(character);
        idleState = new(character);
        attackState = new(character);
        jumpState = new(character);

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
        currentState = state;
        state.EnterState(this);
    }
}
