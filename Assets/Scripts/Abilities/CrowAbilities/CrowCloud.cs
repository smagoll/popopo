using UnityEngine;

public class CrowCloud : Ability
{
    public CrowCloud(Character character) : base(character) { }

    public override void Action()
    {
            Debug.Log("CrowCloud");
    }
}

