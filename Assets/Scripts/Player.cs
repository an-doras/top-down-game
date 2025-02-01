using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private float maxHP = 50.0f;
    protected float curentHP;
    [SerializeField] private Image hpBar;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();// get truc tiep tu player obj
        animator = rb.GetComponent<Animator>();
    }
    void Start()
    {
        curentHP = maxHP;
    }

    void Update()
    {
        MovePlayer();
        UpdateHpBar();
    }

    void MovePlayer()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //lay vi tri cua player
        rb.linearVelocity = playerInput.normalized * moveSpeed; // tranh player di cheo nhanh hon
        
        // giup player nhinh theo huong di chuyen
        if (playerInput.x < 0)
        {
            spriteRenderer.flipX = true;//lat trai
        }
        else if (playerInput.x > 0)
        {
            spriteRenderer.flipX = false;//lat phai
        }
        // tao animation run <-> idle
        if (playerInput != Vector2.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }
    public void TakeDamage(float damage)
    {
        curentHP -= damage;
        curentHP = Mathf.Max(curentHP, 0);
        if (curentHP <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void UpdateHpBar()
    {
        hpBar.fillAmount = curentHP / maxHP;
    }
}
