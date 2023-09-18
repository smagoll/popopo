using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IAbilities, IAttack
{
    #region UI

    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private ManaBar manaBar;

    #endregion

    public Indicators indicators;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        SetCharacteristics();
        InitIndicators();
        rb = GetComponent<Rigidbody2D>();
        FlipToEnemy();
    }

    #region Characteristics

    [SerializeField]
    private float maxHp;
    [SerializeField]
    private float maxMp;
    [SerializeField]
    private float damage;

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
    private float timeCurrentAttack = 0f;
    [SerializeField]
    public float timeStartAttack;
    [SerializeField]
    private float timeInStun;

    [SerializeField]
    private GameObject attackObject;

    [SerializeField]
    private float attackRange;
    [SerializeField]
    private LayerMask layerEnemy;
    public List<GameObject> enemies;

    private bool isGrounded = true;
    private bool isBlock = false;
    public bool isStun = false;


    public Rigidbody2D rb;
    [SerializeField]
    private float speedMove;
    [SerializeField]
    private float speedJump;
    private bool flipRight = true;

    
    public Animator animator;

    public Vector3 DirectionToCloseEnemy()
    {
        FindEnemies();
        var heading = enemies.ToArray()[0].transform.position - transform.position;
        var direction = heading / heading.magnitude;
        return direction;
    }

    public void FlipToEnemy()
    {
        var direction = DirectionToCloseEnemy();
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
            enemy.GetComponent<Character>().TakeDamage(damage);
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
        this.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        Debug.Log(gameObject.name + " dead)");
    }

    public void TakeDamage(float damage) // получение урона
    {
        if (isBlock)
        {
            Hp -= damage/3;
        }
        else
        {
            animator.SetTrigger("damage");
            Hp -= damage;
            StartCoroutine(Stun());
        }
    }

    public void OnBlock()
    {
        isBlock = true;
    }

    public void ExitBlock()
    {
        isBlock = false;
    }

    private IEnumerator Stun() // оглушение персонажа
    {
        isStun = true;
        yield return new WaitForSeconds(timeInStun);
        isStun = false;
    }

    private void FindEnemies()
    {
        var layerNumber = Math.Log(layerEnemy.value, 2);
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
}
