using UnityEngine;

public interface IAttack
{
    public float Damage { get; set; }
    public AnimatorOverrideController AnimatorOV { get; set; }

    /// <summary>
    /// Момент нанесения урона.
    /// </summary>
    void OnAttack(Character character, Character enemy);
    
}