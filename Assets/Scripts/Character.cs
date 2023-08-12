using System;
using UnityEngine;

public class Character : MonoBehaviour, IAbilities
{
    #region UI

    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private ManaBar manaBar;

    #endregion

    private void Start()
    {
        SetCharacteristics();
        rb = GetComponent<Rigidbody2D>();
    }

    #region Characteristics

    [SerializeField]
    private float maxHp;
    [SerializeField]
    private float maxMana;
    [SerializeField]
    private float damage;

    private float hp;
    private float mana;

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
    
    public float Mana
    {
        set
        {
            if (mana + value > maxMana)
            {
                mana = maxMana;
            }
            else
            {
                mana = value;
            }
            manaBar.UpdateMana(value);
        }
        get
        {
            return mana;
        }
    }

    public void SetCharacteristics()
    {
        Hp = maxHp;
        Mana = maxMana;
        healthBar.SetMaxHealth(maxHp);
        manaBar.SetMaxMana(maxMana);
    }

    #endregion

    #region Physics
    private float timeCurrentAttack = 0f;
    [SerializeField]
    private float timeStartAttack;

    [SerializeField]
    private GameObject attackObject;// объет позиции атаки

    [SerializeField]
    private float attackRange;
    [SerializeField]
    private LayerMask enemy;

    private bool isGrounded = true;

    public Rigidbody2D rb;
    [SerializeField]
    private float speedMove;
    [SerializeField]
    private float speedJump;
    private bool flipRight = true;

    
    public Animator animator;

    public void Move(float axisValue)//движение персонажа
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
    }

    private void Flip() // поворот
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

    public void OnAttack()// момент атаки (нанесение урона)
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackObject.transform.position, attackRange, enemy);
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<Character>().TakeDamage(damage);
        }
    }

    public bool Attack(bool input)// атака (возвращает true если совершена атака)
    {
        if (timeCurrentAttack <= 0)
        {
            if (input)
            {
                animator.SetTrigger("attack");
                timeCurrentAttack = timeStartAttack;
                return true;
            }
            return false;
        }
        else
        {
            timeCurrentAttack -= Time.deltaTime;
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // проверка есть ли земля под ногами
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isGrounded = true;
    }

    private void Death() // смерть персонажа
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
        Debug.Log(gameObject.name + " dead)");
    }

    public void TakeDamage(float damage) // получение урона
    {
        Hp -= damage;
        animator.SetTrigger("damage");
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
