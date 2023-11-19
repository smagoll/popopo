using UnityEngine;

public class Teleport : Ability
{
    [SerializeField]
    private float damage;

    public override void Action()
    {
        var enemy = character.GetCloseEnemy();
        var directonToEnemy = character.GetDirectionToCloseEnemy();
        transform.position = enemy.transform.position + directonToEnemy;
        character.FlipToEnemy();
        enemy.GetComponent<Character>().TakeDamage(damage);
    }

    public override void UseAbility(float distance)
    {
        if (distance > distanceUse && isActive == false)
        {
            Launch();
        }
    }
}
