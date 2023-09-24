using System;
using System.Collections;
using UnityEngine;

public class Crow : Character
{
    public override void FirstAbility()
    {
        var ability = new CrowCloud(this);
        if (ability.manapool < Mp)
        {
            Mp -= ability.manapool;
            animator.SetTrigger("first_ability");
            ability.Start();
        }
        else
            return;
    }
}
