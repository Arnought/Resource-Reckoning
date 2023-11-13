using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public Text killCountText;
    private int killCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UpdateKillCountText()
    {
        if (killCountText != null)
        {
            killCountText.text = "Kills: " + killCount.ToString();
        }
    }

    private void OnEnable()
    {
        EnemyHealth.OnEnemyDeath += HandleEnemyDeath;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyDeath -= HandleEnemyDeath;
    }

    void HandleEnemyDeath()
    {
        killCount++;
        UpdateKillCountText();
    }
}
