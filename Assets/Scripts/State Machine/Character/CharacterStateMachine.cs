using UnityEngine;
public class CharacterStateMachine : MonoBehaviour
{
    private Character character;

    private CharacterState currentState;
    public CharacterWalkState walkState;
    public CharacterIdleState idleState;
    public CharacterAttackState attackState;
    public CharacterJumpState jumpState;
    public CharacterBlockState blockState;
    public CharacterDuckState duckState;
    public CharacterSkillState skillState;
    public CharacterStunState stunState;

    public InputAsset input;

    private void Awake()
    {
        character = gameObject.GetComponent<Character>();

        walkState = new(character);
        idleState = new(character);
        attackState = new(character);
        jumpState = new(character);
        blockState = new(character);
        duckState = new(character);
        skillState = new(character);
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

    public void SwitchState(CharacterState state)
    {
        currentState.ExitState(this);
        character.FlipToEnemy();
        currentState = state;
        state.EnterState(this);
    }

    public void OnHurt()
    {
        if (currentState == stunState)
        {
            stunState.startTime = Time.time;
        }
        else
            SwitchState(stunState);
    }
}
