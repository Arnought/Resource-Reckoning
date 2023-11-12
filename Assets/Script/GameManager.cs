using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Over UI")]
    public bool isEnd = false;
    [SerializeField] private GameObject gameOver;

    [Header("Timer UI")]
    public Text timerText;
    private float startTime;

    public PlayerResource player;


    private void Awake()
    {
        startTime = Time.time;
        Instance = this;

        if(gameOver != null)
        {
            gameOver.SetActive(false);
        }

        if(player == null)
        {
            Debug.LogError("Player reference not set in the Game Over");
        }
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;
        UpdateTimerText(elapsedTime);

        if(player != null && player.currentHealth <= 0)
        {
            ShowGameOver();
        }
    }

    void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}: {1:00}", minutes, seconds);
    }

    public void ShowGameOver()
    {
        if (gameOver != null)
        {
            gameOver.SetActive(true);
        }
        
    }
}
