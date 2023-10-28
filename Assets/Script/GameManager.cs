using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isEnd = false;
    [SerializeField] private GameObject gameOver;
    public static GameManager Instance;


    private void Awake()
    {
        Instance = this;
    }

    public void Gamestatus(bool status)
    {
        isEnd = status;

        gameOver.SetActive(status);

        Time.timeScale = 0;
        
    }
}
