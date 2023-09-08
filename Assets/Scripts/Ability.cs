using UnityEngine;

public abstract class Ability
{
    private bool isAbility = false; // активна ли способность
    private int manapool;
    private int damage;
    public Character character;

    public Ability(Character character)
    {
        this.character = character;
    }

    public void Start()
    {
        if (!isAbility && character.Mp > manapool)
        {
            character.Mp -= manapool;
            //animator.SetTrigger("Attack");
            Action();
            isAbility = !isAbility;
            Debug.Log(isAbility);
        }
    }

    public abstract void Action();
}
