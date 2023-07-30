using UnityEngine;

public class CrowCloud : IAbility
{
    private int manapool;
    private int damage;
    public int ManaPool { get => manapool; set => manapool = value; }
    public int Damage { get => damage; set => damage = value; }

    public void Start()
    {
        Debug.Log("CrowCloud");
    }
}

