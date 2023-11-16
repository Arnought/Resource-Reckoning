using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisibility : MonoBehaviour
{
    private Light playerLight;
    private Renderer enemyRenderer;

    void Start()
    {
        // Assuming the player's light is on the same GameObject as the script
        playerLight = GetComponent<Light>();

        // Assuming the enemy has a renderer (MeshRenderer or SpriteRenderer)
        enemyRenderer = GetComponent<Renderer>();

        if (playerLight == null)
        {
            Debug.LogError("Player light not found. Make sure the script is attached to the player's light GameObject.");
        }

        if (enemyRenderer == null)
        {
            Debug.LogError("Enemy renderer not found. Make sure the script is attached to the enemy GameObject with a renderer component.");
        }
    }

    void Update()
    {
        if (IsEnemyVisible())
        {
            // Enemy is within the spotlight, make it visible
            enemyRenderer.enabled = true;
        }
        else
        {
            // Enemy is outside the spotlight, make it invisible
            enemyRenderer.enabled = false;
        }
    }

    bool IsEnemyVisible()
    {
        // Check if the enemy is within the cone of the player's spotlight
        Vector3 toEnemy = transform.position - playerLight.transform.position;
        float angleToEnemy = Vector3.Angle(playerLight.transform.forward, toEnemy);

        // Check if the enemy is within the spotlight's angle
        if (angleToEnemy <= playerLight.spotAngle / 2f)
        {
            // Check if there are no obstacles between the light and the enemy
            RaycastHit hit;
            if (Physics.Raycast(playerLight.transform.position, toEnemy, out hit, playerLight.range))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // The enemy is in the spotlight and not blocked by obstacles
                    return true;
                }
            }
        }

        // Enemy is either outside the spotlight or blocked by obstacles
        return false;
    }
}
