using UnityEngine;

[CreateAssetMenu(fileName = "Indicators Asset", menuName = "Indicators")]
public class Indicators : ScriptableObject
{
    [SerializeField]
    private float timeStartAttack;
    [SerializeField]
    private float timeInStun;
    [SerializeField]
    private float stunAfterAttack;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float speedMove;
    [SerializeField]
    private float speedJump;

    public float TimeStartAttack => timeStartAttack;
    public float TimeInStun => timeInStun;
    public float StunAfterAttack => stunAfterAttack;
    public float AttackRange => attackRange;
    public float SpeedMove => speedMove;
    public float SpeedJump => speedJump;
}
