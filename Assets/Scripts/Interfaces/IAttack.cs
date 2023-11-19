using UnityEngine;

public interface IAttack
{
    public float Damage { get; set; }
    public AnimationClip Animation { get; set; }

    /// <summary>
    /// Момент нанесения урона.
    /// </summary>
    void OnAttack(Character character, Character enemy);
    
}