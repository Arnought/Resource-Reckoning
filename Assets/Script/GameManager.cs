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

    [Header("Quest Complete UI")]
    [SerializeField] private GameObject questComplete;

    [Header("Timer UI")]
    public Text timerText;
    private float startTime;

    public PlayerResource player;

    public Enemy[] enemies;

    private bool isGamePaused = false;


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

        if(enemies == null || enemies.Length == 0)
        {
            Debug.LogError("Enemy references not set in the GameOverManager");
        }
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;
        UpdateTimerText(elapsedTime);

        if(player != null && player.currentHealth <= 0)
        {
            if(!isGamePaused)
            {
                ShowGameOver();
                PauseGame();
            }
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

    void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;

        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            enemy.enabled = false;
        }

        if (timerText != null)
        {
            timerText.enabled = false;
        }
    }
}
