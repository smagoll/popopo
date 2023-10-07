using System;
using System.Collections;
using UnityEngine;

public class Crow : Character
{
    [SerializeField]
    private CrowCloud crowcloud;
    [SerializeField]
    private Teleport teleport;
    [SerializeField]
    private NuclearSmoke nuclearSmoke;

    public override void FirstAbility()
    {
        if (crowcloud.manapool < Mp)
        {
            Mp -= crowcloud.manapool;
            animator.SetTrigger("first_ability");
            crowcloud.Launch();
        }
        else
            return;
    }

    public override void SecondAbility()
    {
        if (teleport.manapool < Mp)
        {
            Mp -= teleport.manapool;
            animator.SetTrigger("second_ability");
            teleport.Launch();
        }
        else
            return;
    }

    public override void Ultimate()
    {
        if (nuclearSmoke.manapool < Mp)
        {
            Mp -= nuclearSmoke.manapool;
            animator.SetTrigger("ultimate");
            nuclearSmoke.Launch();
        }
        else
            return;
    }
}
