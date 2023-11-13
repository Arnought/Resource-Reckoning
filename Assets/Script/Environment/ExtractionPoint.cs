using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionPoint : MonoBehaviour
{
    [SerializeField] private bool isPlayerInside = false;
    public GameObject questCompleteUI;
    public float countdownTime = 3f;

    public Transform extractionPointLocation; // Reference to the location where the extraction point should appear.

    private Barrel_Counter barrelCounter; // Reference to the Barrel_Counter script.
    private bool hasActivated = false; // To ensure the extraction point activates only once.

    void Start()
    {
        // Find the Barrel_Counter script in the scene.
        barrelCounter = FindObjectOfType<Barrel_Counter>();

        if (barrelCounter == null)
        {
            Debug.LogError("Barrel_Counter script not found in the scene.");
        }

        // Initially hide the extraction point.
        gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if the player has collected all 10 barrels.
        if (barrelCounter != null && barrelCounter.barrelPoint == 10 && extractionPointLocation != null && !hasActivated)
        {
            // Activate the extraction point and set its position.
            transform.position = extractionPointLocation.position;
            transform.rotation = extractionPointLocation.rotation;
            gameObject.SetActive(true);

            hasActivated = true; // Set to true to ensure it activates only once.

            StartCoroutine(StartCountdown());
        }
        else if (hasActivated)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(countdownTime);

        // Show the Quest Complete UI.
        if (questCompleteUI != null)
        {
            questCompleteUI.SetActive(true);

            // Pause the game.
            Time.timeScale = 0f;

            // Disable player movement (replace "PlayerMovementScript" with the actual script name).
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            // Stop enemy movement and spawning (replace "EnemyScript" with the actual script name).
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                enemy.enabled = false;
            }

            // Stop boss movement and spawning (replace "BossScript" with the actual script name).
            Boss boss = FindObjectOfType<Boss>();
            if (boss != null)
            {
                boss.enabled = false;
            }
        }
        else
        {
            Debug.LogError("Quest Complete UI is not assigned in the inspector.");
        }
    }
}
