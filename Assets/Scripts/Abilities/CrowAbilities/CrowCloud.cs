using System.Collections;
using UnityEngine;

public class CrowCloud : Ability
{
    [SerializeField]
    private GameObject prefCrowcloud;

    public override void Action()
    {
        Instantiate(prefCrowcloud);
    }
}

