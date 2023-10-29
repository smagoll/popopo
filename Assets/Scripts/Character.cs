using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Character : MonoBehaviour, IAbilities, IAttack
{
    #region UI

    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private ManaBar manaBar;

    #endregion

    public Indicators indicators;
    public Distance distanceStates;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        layerNumber = Math.Log(layerEnemy.value, 2);
        SetCharacteristics();
        InitIndicators();
        rb = GetComponent<Rigidbody2D>();
        FlipToEnemy();
    }

    #region Characteristics

    [SerializeField]
    public float maxHp;
    [SerializeField]
    public float maxMp;
    public float damage;

    private float hp;
    private float mp;

    public float Hp
    {
        set
        {
            hp = value;
            if (hp <= 0)
            {
                Death();
            }
            healthBar.UpdateHealth(value);
        }
        get
        {
            return hp;
        }
    }
    
    public float Mp
    {
        set
        {
            if (value > maxMp)
            {
                mp = maxMp;
            }
            else
            {
                mp = value;
            }
            manaBar.UpdateMana(value);
        }
        get
        {
            return mp;
        }
    }

    private void InitIndicators()
    {
        hp = maxHp;
        mp = 0f;
        ResetStats();
    }

    public void ResetStats()
    {
        timeStartAttack = indicators.TimeStartAttack;
        timeInStun = indicators.TimeInStun;
        attackRange = indicators.AttackRange;
        speedMove = indicators.SpeedMove;
        speedJump = indicators.SpeedJump;
    }

    public void SetCharacteristics()
    {
        Hp = maxHp;
        Mp = maxMp;
        healthBar.SetMaxHealth(maxHp);
        manaBar.SetMaxMana(maxMp);
    }

    #endregion

    #region Physics
    public float timeStartAttack;
    public float timeInStun;
    public float stunAfterAttack;

    [SerializeField]
    private GameObject attackObject;

    [SerializeField]
    private float attackRange;
    public LayerMask layerEnemy;
    private double layerNumber;
    public List<GameObject> enemies;

    private bool isGrounded = true;
    public bool isBlock = false;
    public bool isStun = false;
    public bool isAttack = false;


    public Rigidbody2D rb;
    public float speedMove;
    public float speedJump;
    [SerializeField]
    private float forcePush;
    private bool flipRight = true;

    
    public Animator animator;

    [SerializeField]
    private VisualEffect _hit;

    public Vector3 GetDirectionToCloseEnemy()
    {
        FindEnemies();
        var heading = enemies.ToArray()[0].transform.position - transform.position;
        var direction = heading / heading.magnitude;
        return direction;
    }

    public float GetDistanceToCloseEnemy()
    {
        FindEnemies();
        var heading = enemies.ToArray()[0].transform.position - transform.position;
        return heading.magnitude;
    }
    
    public GameObject GetCloseEnemy()
    {
        FindEnemies();
        return enemies[0];
    }

    public void FlipToEnemy()
    {
        var direction = GetDirectionToCloseEnemy();
        if (direction.x > 0 && !flipRight)
        {
            Flip();
        }
        if (direction.x < 0 && flipRight)
        {
            Flip();
        }     
    }

    public void Move(float axisValue) // передвижение персонажа
    {
        rb.velocity = new Vector2(axisValue * speedMove, rb.velocity.y);

        if (axisValue > 0 && !flipRight)
        {
            Flip();
        }
        else if (axisValue < 0 && flipRight)
        {
            Flip();
        }
        PreventPlayerGoingOffScreen();
    }

    private void PreventPlayerGoingOffScreen() // ограничение выхода за камеру персонажа
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < 0 && rb.velocity.x < 0) || (screenPosition.x > _camera.pixelWidth && rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void Flip() // поворот персонажа
    {
        flipRight = !flipRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Jump() // прыжок
    {
        if (isGrounded)
        {
            animator.SetTrigger("jump");
            isGrounded = false;
            rb.AddForce(Vector2.up * speedJump, ForceMode2D.Impulse);
        }
    }

    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackObject.transform.position, attackRange, layerEnemy);
        foreach (var enemy in enemies)
        {
            if (enemy.CompareTag("hero"))
            {
                var charEnemy = enemy.GetComponent<Character>();
                charEnemy.TakeDamageWithStun(damage);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // проверка земли под ногами
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isGrounded = true;
    }

    private void Death() // смерть
    {
        animator.SetTrigger("death");
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        Debug.Log(gameObject.name + " dead)");
    }

    public void TakeDamageWithStun(float damage) // получение урона
    {
        if (isBlock)
        {
            Hp -= damage/3;
        }
        else
        {
            Hp -= damage;
            animator.SetTrigger("damage");
            _hit.SendEvent("OnHit");
        }
    }
    
    public void TakeDamage(float damage) // получение урона
    {
        Hp -= damage;
        _hit.SendEvent("OnHit");
    }

    public void TakePush(float forcePush, Vector3 direction)
    {
        if (isBlock)
        {
            return;
        }
        rb.AddForce(direction * forcePush, ForceMode2D.Impulse);
    }

    public void OnAttackWithPush()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackObject.transform.position, attackRange, layerEnemy);
        foreach (var enemy in enemies)
        {
            if (enemy.CompareTag("hero"))
            {
                var charEnemy = enemy.GetComponent<Character>();
                charEnemy.TakeDamageWithStun(damage);
                charEnemy.TakePush(forcePush, GetDirectionToCloseEnemy());
                charEnemy._hit.SendEvent("OnHit");
            }
        }
    }

    public void TakeStun()
    {
        StartCoroutine(Stun());
    }

    public void EnterStun()
    {
        isStun = true;
    }

    public void ExitStun()
    {
        isStun = false;
    }

    private IEnumerator Stun() // оглушение персонажа
    {
        isStun = true;
        yield return new WaitForSeconds(timeInStun);
        isStun = false;
    }

    private void FindEnemies()
    {
        enemies.Clear();
        var heroes = GameObject.FindGameObjectsWithTag("hero");
        foreach (var hero in heroes)
        {
            if (hero.layer == layerNumber)
            {
                enemies.Add(hero);
            }
        }
    }

    #endregion

    public virtual void FirstAbility()
    {
        throw new NotImplementedException();
    }

    public virtual void SecondAbility()
    {
        throw new NotImplementedException();
    }

    public virtual void Ultimate()
    {
        throw new NotImplementedException();
    }

    public virtual void UseAbilities()
    {
        throw new NotImplementedException();
    }
}
