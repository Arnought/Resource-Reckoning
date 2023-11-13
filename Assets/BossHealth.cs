using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 15;
    public int currentHealth;

    public delegate void BossDeath();
    public static event BossDeath OnBossDeath;

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
        OnBossDeath?.Invoke();

        Destroy(gameObject);
    }
}
