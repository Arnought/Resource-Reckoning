using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerResource : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int killCount = 0;

    public HealthBar healthBar;
    public Text killCountText;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        if(killCountText == null)
        {
            Debug.LogError("killCountText reference not set in the PlayerResource script.");
        }

        UpdateKillCountText();
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player has been Defeated");
        }
    }

    public void IncreaseKillCount()
    {
        killCount++;
        UpdateKillCountText();
    }

    void UpdateKillCountText()
    {
        if(killCountText != null)
        {
            killCountText.text = "Kills: " + killCount.ToString();
        }
    }
}
