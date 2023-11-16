using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearSmoke : Ability
{
    [SerializeField]
    private float scale;
    [SerializeField]
    private float timeInRage;

    public override void Action()
    {
        StartCoroutine(Rage());
    }

    public override void UseAbility(float distance)
    {
        if (distance > distanceUse && isActive == false)
        {
            Launch();
        }
    }

    private IEnumerator Rage()
    {
        character.speedMove *= scale;
        character.damage *= scale;
        character.timeStartAttack /= scale;
        character.stunAfterAttack /= scale;
        character.animator.speed *= scale;
        yield return new WaitForSeconds(timeInRage);
        character.ResetStats();
        character.animator.speed = 1f;
    }
}
