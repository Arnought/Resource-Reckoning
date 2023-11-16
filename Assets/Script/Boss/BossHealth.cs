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

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        OnBossDeath?.Invoke();

        Destroy(gameObject);
    }
}
