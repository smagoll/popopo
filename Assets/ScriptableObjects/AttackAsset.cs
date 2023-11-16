using UnityEngine;

[CreateAssetMenu(fileName = "Default Attack", menuName = "DefaultAttack")]
public class AttackAsset : ScriptableObject, IAttack
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private AnimatorOverrideController animatorOV;

    public float Damage { get => damage; set => damage = value; }
    public AnimatorOverrideController AnimatorOV { get => animatorOV; set => animatorOV = value; }

    public void OnAttack(Character character, Character enemy)
    {
        enemy.TakeDamageWithStun(damage);
        character.Mp += damage / 3;
        animatorOV.animationClips[0] = new AnimationClip();
    }
}
