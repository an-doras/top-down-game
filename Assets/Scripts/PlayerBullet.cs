using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeedbullet = 24f;
    [SerializeField] private float timeDestroy = 0.5f;
    [SerializeField] private float damage = 20.0f;
    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }

    void Update()
    {
        MoveBullet();
    }
    void MoveBullet()
    {
        transform.Translate(Vector2.right * moveSpeedbullet * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
                {
                enemy.TakeDamage(damage);
                }
            Destroy(gameObject);
        }
    }
}
