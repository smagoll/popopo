using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicPuddle : Ability
{
    [SerializeField]
    private GameObject prefToxicDrop;
    public float timePuddle;
    public float damage;
    public float freqDamage;
    public float forcePushDrop;

    public override void Action()
    {
        var drop = Instantiate(prefToxicDrop, position: gameObject.transform.position, Quaternion.identity);
        drop.GetComponent<ToxicDrop>().controller = this;
        isActive = true;
    }

    public override void UseAbility(float distance)
    {
        if (distance < distanceUse && isActive == false)
        {
            Launch();
        }
    }
}
