using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float moveSpd;
    [SerializeField] private Transform target;
    private Rigidbody2D rgbd2d;
    [SerializeField] private int damage = 15;

    private bool isPlayerInRange = false;
    public float damageInterval = 1f; // Time interval between each damage tick.
    private float damageTimer = 0f;

    private HealthBar healthBar; // Reference to the HealthBar.
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rgbd2d = GetComponent<Rigidbody2D>();

        // Find the HealthBar in the scene or instantiate it if necessary.
        healthBar = FindObjectOfType<HealthBar>();

        if (healthBar == null)
        {
            Debug.LogError("HealthBar not found. Make sure it's present in the scene.");
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        // Move towards the player
        rgbd2d.velocity = direction * moveSpd;

        // Set the Direction parameter for the Blend Tree
        animator.SetFloat("Direction", direction.x);

        if (isPlayerInRange)
        {
            damageTimer -= Time.fixedDeltaTime;

            if (damageTimer <= 0f)
            {
                // Time to deal damage again.
                DealContinuousDamage();
                damageTimer = damageInterval; // Reset the timer.
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void DealContinuousDamage()
    {
        PlayerResource playerHealth = target.GetComponent<PlayerResource>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);

            // Update the health bar using the SetHealth method.
            if (healthBar != null)
            {
                healthBar.SetHealth(playerHealth.currentHealth);
            }

            Attack(); // Call the Attack function when the enemy successfully hits the player.
        }
    }

    private void Attack()
    {
        Debug.Log("Enemy dealt " + damage + " damage to the player!");
    }
}
