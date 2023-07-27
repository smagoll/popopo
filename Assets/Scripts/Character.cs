using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float hp;
    [SerializeField]
    private float damage;

    private float timeCurrentAttack = 0f;
    [SerializeField]
    private float timeStartAttack;

    private GameObject attackObject;// объет позиции атаки
    private float attackPosX = 1f;// смещение атаки по оси X относительно персонажа

    [SerializeField]
    private float attackRange;
    [SerializeField]
    private LayerMask enemy;

    private bool isGrounded = true;

    private Rigidbody2D rb;
    [SerializeField]
    private float speedMove;
    [SerializeField]
    private float speedJump;
    private bool flipRight = true;
    private bool isRunning = false;

    [SerializeField] 
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //attackPos.position = gameObject.transform.position + new Vector3(attackPosX, 0, 0);
        attackObject = Instantiate(new GameObject(), gameObject.transform);
        attackObject.transform.position = gameObject.transform.position + new Vector3(attackPosX, 0, 0);
    }

    private void Update()
    {

    }

    public void Move(float axisValue)//движение персонажа
    {
        rb.velocity = new Vector2(axisValue * speedMove, rb.velocity.y);

        animator.SetFloat("HorizontalMove", Mathf.Abs(axisValue));

        if (axisValue > 0 && !flipRight)
        {
            Flip();
        }
        else if (axisValue < 0 && flipRight)
        {
            Flip();
        }

        if (axisValue == 0)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }
        
        animator.SetBool("isRunning", isRunning);
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
            isGrounded = false;
            rb.AddForce(Vector2.up * speedJump, ForceMode2D.Impulse);
        }
    }

    public void OnAttack()//
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackObject.transform.position, attackRange, enemy);
        foreach (var enemy in enemies)
        {
            Debug.Log(enemy.name + "take damage");
        }
    }

    public void Attack(bool input)// атака
    {
        if (timeCurrentAttack <= 0)
        {
            if (input)
            {
                animator.SetTrigger("Attack");
                timeCurrentAttack = timeStartAttack;
                Debug.Log("animation attack");
            }
        }
        else
        {
            timeCurrentAttack -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // проверка есть ли земля под ногами
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isGrounded = true;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(attackObject.transform.position, attackRange);
    //}
}
