using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicPuddle : Ability
{
    [SerializeField]
    private GameObject prefToxicDrop;
    public float distance;
    public float timePuddle;
    public float damage;
    public float freqDamage;

    public override void Action()
    {
        var drop = Instantiate(prefToxicDrop, position: gameObject.transform.position, Quaternion.identity);
        drop.GetComponent<ToxicDrop>().controller = this;
    }
}
