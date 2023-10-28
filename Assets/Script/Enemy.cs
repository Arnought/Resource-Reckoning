using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpd;
    [SerializeField] private Transform target;
    GameObject targetGameObject;
    Rigidbody2D rgbd2d;
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        targetGameObject = target.gameObject;
        rgbd2d = GetComponent<Rigidbody2D>();
    }

   void FixedUpdate()
    {
        
        Vector3 direction = (target.position - transform.position).normalized;
        rgbd2d.velocity = direction * moveSpd;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("HIT!");
    }
}
