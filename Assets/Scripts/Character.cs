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

    private bool isGrounded = true;

    private Rigidbody2D rb;
    [SerializeField]
    private float speedMove;
    [SerializeField]
    private float speedJump;
    private bool flipRight = true;

    [SerializeField] 
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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



    public void Attack(bool input)
    {
        if (timeCurrentAttack <= 0)
        {
            if (input)
            {
                animator.SetTrigger("Attack");
                timeCurrentAttack = timeStartAttack;
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

}
