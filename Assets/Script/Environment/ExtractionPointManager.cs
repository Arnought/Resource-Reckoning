using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ExtractionPointManager : MonoBehaviour
{
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


    public GameObject questCompleteUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Barrel_Counter barrelCounter = FindObjectOfType<Barrel_Counter>();

            if (barrelCounter != null && barrelCounter.barrelPoint == 10)
            {
                Debug.Log("Player entered extraction point trigger");
                QuestComplete();
            }
        }
    }

    void QuestComplete()
    {
        Debug.Log("Quest Complete function called");
        if (questCompleteUI != null)
        {
            questCompleteUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
