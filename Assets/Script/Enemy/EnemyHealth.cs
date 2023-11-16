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

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        OnEnemyDeath?.Invoke();

        Destroy(gameObject);
    }
}
