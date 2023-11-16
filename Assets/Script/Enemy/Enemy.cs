using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpd;
    [SerializeField] private Transform target;
    private Rigidbody2D rgbd2d;
    [SerializeField] private int damage = 8;

    private bool isPlayerInRange = false;
    public float damageInterval = 1f;
    private float damageTimer = 0f;

    private HealthBar healthBar;

    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rgbd2d = GetComponent<Rigidbody2D>();

        healthBar = FindObjectOfType<HealthBar>();

        if (healthBar == null)
        {
            Debug.LogError("HealthBar not found. Make sure it's present in the scene.");
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        rgbd2d.velocity = direction * moveSpd;

        animator.SetFloat("Direction", direction.x);

        if (isPlayerInRange)
        {
            damageTimer -= Time.fixedDeltaTime;

            if (damageTimer <= 0f)
            {

                DealContinuousDamage();
                damageTimer = damageInterval;
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

            if(healthBar != null)
            {
                healthBar.SetHealth(playerHealth.currentHealth);
            }

            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Enemy dealt " + damage + " damage to the player!");
    }
}
