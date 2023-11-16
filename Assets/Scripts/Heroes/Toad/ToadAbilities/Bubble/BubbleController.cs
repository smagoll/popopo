using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : Ability
{
    [SerializeField]
    private Bubble prefabBubble;
    public float damage;
    public float timeBubble;
    public float freqDamage;

    public override void Action()
    {
        var bubble = Instantiate(prefabBubble, gameObject.transform);
        bubble.controller = this;
        isActive = true;
    }

    public override void UseAbility(float distance)
    {
        if (distance > distanceUse && isActive == false)
        {
            Launch();
        }
    }
}
