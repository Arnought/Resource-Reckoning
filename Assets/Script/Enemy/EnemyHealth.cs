using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 15;
    public int currentHealth;

    public delegate void EnemyDeath();
    public static event EnemyDeath OnEnemyDeath;

    private Transform target;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if the enemy's health is zero or below.
        if (currentHealth <= 0)
        {
            // Perform any additional actions when the enemy is defeated.
            Die();
        }
    }

    void Die()
    {
        OnEnemyDeath?.Invoke();

        Destroy(gameObject);
    }
}
