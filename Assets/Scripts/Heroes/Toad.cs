using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : Character
{
    [SerializeField]
    private float coolDownAbility;
    [SerializeField]
    private ToxicPuddle toxicPuddle;
    private float lastClickTime = 0f;

    public override void FirstAbility()
    {
        if (toxicPuddle.manapool < Mp)
        {
            Mp -= toxicPuddle.manapool;
            animator.SetTrigger("first_ability");
            toxicPuddle.Launch();
        }
        else
            return;
    }

    public override void UseAbilities()
    {
        var distance = GetDistanceToCloseEnemy();

        if (Time.time - lastClickTime < coolDownAbility)
        {
            return;
        }

        if (distance < toxicPuddle.distance)
        {
            FirstAbility();
            lastClickTime = Time.time;
            return;
        }
    }
}
