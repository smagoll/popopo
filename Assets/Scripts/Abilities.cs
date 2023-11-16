using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour, IAbilities
{
    public Ability firstAbility;
    public Ability secondAbility;
    public Ability ultimate;

    private Character character;

    private void Start()
    {
        character = gameObject.GetComponent<Character>();
    }

    public void FirstAbility()
    {
        firstAbility.Launch();
    }

    public void SecondAbility()
    {
        secondAbility.Launch();
    }

    public void Ultimate()
    {
        ultimate.Launch();
    }

    public void UseAbilities(float distance)
    {
        if (character.useAbility)
        {
            return;
        }

        firstAbility.UseAbility(distance);
        secondAbility.UseAbility(distance);
        ultimate.UseAbility(distance);
    }
}
