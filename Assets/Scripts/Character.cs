using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Character : MonoBehaviour
{
    #region UI

    public HealthBar healthBar;
    public ManaBar manaBar;

    #endregion

    public Indicators indicators;
    public Distance distanceStates;
    private Camera _camera;
    public AttackController attackController;

    private void Start()
    {
        _camera = Camera.main;
        layerNumber = Math.Log(layerEnemy.value, 2);
        SetBars();
        InitIndicators();
        rb = GetComponent<Rigidbody2D>();
        attackController = GetComponent<AttackController>();
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
        stunAfterAttack = indicators.StunAfterAttack;
        speedMove = indicators.SpeedMove;
        speedJump = indicators.SpeedJump;
    }

    public void SetBars()
    {
        healthBar.SetMaxHealth(maxHp);
        manaBar.SetMaxMana(maxMp);
    }

    #endregion

    #region Physics
    public float timeStartAttack;
    public float timeInStun;
    public float stunAfterAttack;

    public GameObject attackObject;

    public LayerMask layerEnemy;
    public double layerNumber;
    public List<GameObject> enemies;

    private bool isGrounded = true;
    public bool isBlock = false;
    public bool isStun = false;
    public bool isAttack = false;
    public bool isDead = false;
    public bool useAbility = false; // используется ли способность


    public Rigidbody2D rb;
    public float speedMove;
    public float speedJump;
    [SerializeField]
    private float forcePush;
    private bool flipRight = true;

    
    public Animator animator;
    public Abilities abilities;
    public VisualEffect _hit;

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

    private void OnCollisionEnter2D(Collision2D collision) // проверка земли под ногами
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isGrounded = true;
    }

    private void Death() // смерть
    {
        isDead = true;
        animator.SetBool("death", true);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        GlobalEventManager.Start_EndGame();
    }

    public void TakeDamage(float damage) // получение урона
    {
        Hp -= damage;
        Mp += damage / 2;
        _hit.SendEvent("OnHit");
    }

    public void EnterStun()
    {
        isStun = true;
    }

    public void ExitStun()
    {
        isStun = false;
    }

    public void TakeStun(float time)
    {
        StartCoroutine(Stun(time));
    }

    private IEnumerator Stun(float time)
    {
        EnterStun();
        yield return new WaitForSeconds(time);
        ExitStun();
    }

    private void FindEnemies() // поиск врагов
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
}
