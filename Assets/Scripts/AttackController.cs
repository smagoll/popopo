using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private Character character;
    public int numAttack;
    public IAttack[] attacks;
    public GameObject attackObject;
    public float attackRange;

    private void Start()
    {
        character = GetComponent<Character>();
    }

    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackObject.transform.position, attackRange, character.layerEnemy);
        foreach (var enemy in enemies)
        {
            if (enemy.CompareTag("hero"))
            {
                var charEnemy = enemy.GetComponent<Character>();
                attacks[numAttack].OnAttack(character, charEnemy);
            }
        }
    }
}
