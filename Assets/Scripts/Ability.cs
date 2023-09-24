using UnityEngine;

public abstract class Ability
{
    public float manapool = 20f;
    public Character character;

    public Ability(Character character)
    {
        this.character = character;
    }

    public void Start()
    {
        Action();
    }

    public abstract void Action();
}
