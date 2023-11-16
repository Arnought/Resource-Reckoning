using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtractionPointManager : MonoBehaviour
{
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

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
