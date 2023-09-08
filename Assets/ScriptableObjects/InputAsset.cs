using UnityEngine;

[CreateAssetMenu(fileName = "Input Asset", menuName = "Input")]
public class InputAsset : ScriptableObject
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode down;
    public KeyCode up;
    public KeyCode attack;
    public KeyCode adittionalAttack;
    public KeyCode block;
    public KeyCode skill;
}
