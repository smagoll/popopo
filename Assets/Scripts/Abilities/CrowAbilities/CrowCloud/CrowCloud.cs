using System.Collections;
using UnityEngine;

public class CrowCloud : Ability
{
    [SerializeField]
    private GameObject prefCrowcloud;
    public float speed;
    [SerializeField]
    private Transform spawnCrowcloud;
    public override void Action()
    {
        var crowcloudObject = Instantiate(prefCrowcloud , position: spawnCrowcloud.position, Quaternion.identity);
        var cloud = crowcloudObject.GetComponent<Cloud>();
        cloud.crowCloud = this;

    }
}

