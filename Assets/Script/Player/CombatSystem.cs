using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public Transform firePoint; // The position from where the bullet will be instantiated.
    public GameObject bulletPrefab; // Reference to the bullet prefab.
    public float bulletSpeed = 10f; // Speed of the bullet.

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click.
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Get mouse position in world coordinates.
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get the fire point position.
        Vector2 firePointPosition = firePoint.position;

        // Calculate the direction from the fire point to the mouse position.
        Vector2 shootDirection = (mousePosition - firePointPosition).normalized;

        // Instantiate the bullet at the fire point position.
        GameObject bullet = Instantiate(bulletPrefab, firePointPosition, Quaternion.identity);

        // Access the rigidbody2D component of the bullet and set its velocity.
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y) * bulletSpeed;
    }

}
