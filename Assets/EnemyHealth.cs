using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 15;
    private int currentHealth;

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
            Destroy(gameObject);
        }
    }
}
