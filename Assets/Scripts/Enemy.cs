using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1.0f;
    protected Player player;
    [SerializeField] protected float maxHP = 50.0f;
    protected float curentHP;
    [SerializeField] private Image hpBar;

    [SerializeField] protected float enterDamage = 10.0f;
    [SerializeField] protected float stayDamage = 1.0f;
    protected virtual void Start()
    {
        player = FindAnyObjectByType<Player>();
        curentHP = maxHP;
    }
    protected virtual void Update()
    {
        MoveToPLayer();
        UpdateHpBar();
    }
    protected void MoveToPLayer()
    {
        if (player != null) // check tham chieu den player chua
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);// di chuyen den player
            FlipEnemy();
        }
    }
    protected void FlipEnemy()
    {
        if (player != null)
        {
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1,1,1);
        }
    }
    public virtual void TakeDamage(float damage = 10.0f)
    {
        curentHP -= damage;
        curentHP = Mathf.Max(curentHP, 0);
        if (curentHP <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    protected void UpdateHpBar()
    {
        if(hpBar != null)
        {
            hpBar.fillAmount = curentHP / maxHP;
        }
    }
}