using UnityEngine;

public class EnergyEnemy : Enemy
{
    [SerializeField] private GameObject energyObjects;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(enterDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(stayDamage);
        }
    }
    protected override void Die()
    {
        if(energyObjects != null)
        {
            GameObject enemy = Instantiate(energyObjects, transform.position, Quaternion.identity);
            Destroy(enemy,5f);
        }
        base.Die();
    }
}
