using System;
using System.Collections;
using UnityEngine;

public class Crow : Character
{
    [SerializeField]
    private CrowCloud crowcloud;

    public override void FirstAbility()
    {
        var ability = gameObject.GetComponent<CrowCloud>();
        if (ability.manapool < Mp)
        {
            Mp -= ability.manapool;
            animator.SetTrigger("first_ability");
            ability.Launch();
        }
        else
            return;
    }
}
