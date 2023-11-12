using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isEnd = false;
    [SerializeField] private GameObject gameOver;
    public static GameManager Instance;

    public Text timerText;
    private float startTime;


    private void Awake()
    {
        startTime = Time.time;
        Instance = this;
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;
        UpdateTimerText(elapsedTime);
    }

    void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}: {1:00}", minutes, seconds);
    }

    public void Gamestatus(bool status)
    {
        isEnd = status;

        gameOver.SetActive(status);

        Time.timeScale = 0;
        
    }
}
