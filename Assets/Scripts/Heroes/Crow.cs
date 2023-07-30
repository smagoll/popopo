using System;
using UnityEngine;

public class Crow : Character
{
    public override void FirstMainAbility()
    {
        if(Mana > 30)
        {
            Mana -= 30;
            Debug.Log("first");
        }
    }

    public override void SecondMainAbility()
    {
        throw new NotImplementedException();
    }

    public override void Ultimate()
    {
        throw new NotImplementedException();
    }
}
