using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoController : Ability
{
    [SerializeField]
    private GameObject prefabLasso;
    public float speedLasso;
    public float longitudeLasso;
    public float timeStunEnemyAfterAttraction;

    public override void Action()
    {
        var lasso = Instantiate(prefabLasso, character.transform);
        lasso.GetComponent<Lasso>().controller = this;
        isActive = true;
        character.useAbility = true;
    }

    public override void UseAbility(float distance)
    {
        if (distance < distanceUse && isActive == false)
        {
            Launch();
        }
    }
}
