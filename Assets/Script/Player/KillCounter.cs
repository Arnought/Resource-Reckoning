using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public Text killCountText;
    private int killCount = 0;

    void UpdateKillCountText()
    {
        if (killCountText != null)
        {
            killCountText.text = "Kill: " + killCount.ToString();
        }
    }

    private void OnEnable()
    {
        EnemyHealth.OnEnemyDeath += HandleEnemyDeath;
        BossHealth.OnBossDeath += HandleBossDeath;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyDeath -= HandleEnemyDeath;
        BossHealth.OnBossDeath -= HandleBossDeath;
    }

    void HandleEnemyDeath()
    {
        killCount++;
        UpdateKillCountText();
    }

    void HandleBossDeath()
    {
        killCount++;
        UpdateKillCountText();
    }
}
