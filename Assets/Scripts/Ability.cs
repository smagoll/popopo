using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public float manapool;
    public Character character;
    public float cooldown;
    public bool isActive = false;
    public float distanceUse;

    private void Start()
    {
        character = gameObject.GetComponent<Character>();
    }

    public void Launch()
    {
        if (manapool <= character.Mp)
        {
            character.Mp -= manapool;
            Action();
        }
        else
            return;
    }

    public abstract void Action();


    public void Cooldown()
    {
        StartCoroutine(CooldownAbility());
    }

    private IEnumerator CooldownAbility()
    {
        yield return new WaitForSeconds(cooldown);
        isActive = false;
    }

    public abstract void UseAbility(float distance);
}
