using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearSmoke : Ability
{
    [SerializeField]
    private float timeInRage;

    public override void Action()
    {
        StartCoroutine(Rage());
    }

    private IEnumerator Rage()
    {
        character.speedMove *= 1.3f;
        character.damage *= 1.3f;
        character.timeStartAttack /= 1.3f;
        yield return new WaitForSeconds(timeInRage);
        character.ResetStats();
    }
}
