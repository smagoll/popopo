using System;
using UnityEngine;

public class Crow : Character
{
    public override void FirstAbility()
    {
        var ability = new CrowCloud(this);
        ability.Start();
    }
}
