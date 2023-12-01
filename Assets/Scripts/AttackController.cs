using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float damage;
    public int maxCombo;
    private Character character;
    public GameObject attackObject;
    public float attackRange;

    private void Start()
    {
        character = GetComponent<Character>();
        attackRange = character.indicators.AttackRange;
    }

    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackObject.transform.position, attackRange, character.layerEnemy);
        foreach (var enemy in enemies)
        {
            if (enemy.CompareTag("hero"))
            {
                var charEnemy = enemy.GetComponent<Character>();
                if (charEnemy.isBlock)
                {
                    charEnemy.TakeDamage(damage / 2);
                    character.Mp += damage / 3;
                }
                else
                {
                    charEnemy.TakeDamage(damage);
                    character.Mp += damage / 3;
                    charEnemy.animator.SetTrigger("damage");
                }
            }
        }
    }
}