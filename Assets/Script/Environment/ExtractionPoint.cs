using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionPoint : MonoBehaviour
{
    /*[SerializeField] private bool isPlayerInside = false;
    public GameObject questCompleteUI;
    public float countdownTime = 3f;

    public Transform extractionPointLocation;

    private Barrel_Counter barrelCounter; 
    private bool hasActivated = false; 

    void Start()
    {
        barrelCounter = FindObjectOfType<Barrel_Counter>();

        if (barrelCounter == null)
        {
            Debug.LogError("Barrel_Counter script not found in the scene.");
        }

        gameObject.SetActive(false);
    }

    void Update()
    {
        if (barrelCounter != null && barrelCounter.barrelPoint == 10 && extractionPointLocation != null && !hasActivated)
        {
            transform.position = extractionPointLocation.position;
            transform.rotation = extractionPointLocation.rotation;
            gameObject.SetActive(true);

            hasActivated = true;

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

        if (questCompleteUI != null)
        {
            questCompleteUI.SetActive(true);

            Time.timeScale = 0f;

            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                enemy.enabled = false;
            }

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
    }*/

    /*public GameObject extractionPoint;
    public Transform extractionPointLocation;
    public GameObject questCompleteUI;

    private Barrel_Counter barrelCounter;
    private bool isPlayerInside = false;
    private bool hasSpawnedExtractionPoint = false;

    void Start()
    {
        barrelCounter = FindObjectOfType<Barrel_Counter>();

        if (barrelCounter == null)
        {
            Debug.LogError("Barrel_Counter script not found in the scene.");
        }

        if (questCompleteUI != null)
        {
            questCompleteUI.SetActive(false);
        }

        if (extractionPoint == null)
        {
            Debug.LogError("Extraction point object not assigned in the inspector.");
        }
        else
        {
            extractionPoint.SetActive(false); // Initially hide the extraction point.
        }
    }

    void Update()
    {
        // Check if the player has collected all 10 barrels.
        if (barrelCounter != null && barrelCounter.barrelPoint == 10 && extractionPointLocation != null && !hasSpawnedExtractionPoint)
        {
            // Make the extraction point visible and set its position.
            extractionPoint.SetActive(true);
            extractionPoint.transform.position = extractionPointLocation.position;
            extractionPoint.transform.rotation = extractionPointLocation.rotation;

            hasSpawnedExtractionPoint = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered extraction point trigger");
            isPlayerInside = true;
            QuestComplete();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited extraction point trigger");
            isPlayerInside = false;
        }
    }

    void QuestComplete()
    {
        Debug.Log("Quest Complete function called");
        if (questCompleteUI != null && isPlayerInside)
        {
            questCompleteUI.SetActive(true);
        }
    }*/
}
