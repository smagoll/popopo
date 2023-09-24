using System.Collections;
using UnityEngine;

public class CrowCloud : Ability
{
    public CrowCloud(Character character) : base(character) { }

    public float timeAbility = 1f;

    public override void Action()
    {
        Debug.Log("CrowCloud start");
    }
}

