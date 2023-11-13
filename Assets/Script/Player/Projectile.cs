using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10; // Set the damage value in the Inspector.

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet hits an enemy.
        if (other.CompareTag("enemy") || other.CompareTag("boss"))
        {
            // Get the EnemyHealth component from the enemy GameObject.
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            BossHealth bossHealth = other.GetComponent<BossHealth>();

            // Check if the enemy has a health component.
            if (enemyHealth != null)
            {
                // Deal damage to the enemy.
                enemyHealth.TakeDamage(damage);
            }
            else if (bossHealth != null)
            {
                bossHealth.TakeDamage(damage);
            }

            // Destroy the bullet on collision with an enemy.
            Destroy(gameObject);
        }
        
        // Check if the bullet hits a wall.
        else if (other.CompareTag("Wall"))
        {
            // Destroy the bullet on collision with a wall.
            Destroy(gameObject);
        }
    }
}
