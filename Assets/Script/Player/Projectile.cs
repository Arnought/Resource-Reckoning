using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy") || other.CompareTag("boss"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            BossHealth bossHealth = other.GetComponent<BossHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            else if (bossHealth != null)
            {
                bossHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
