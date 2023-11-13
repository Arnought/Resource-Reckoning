using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;
    public float spawnTime = 300f;

    private float elapsedTime = 0f;

    private void Start()
    {
        if(bossSpawnPoint == null)
        {
            Debug.LogError("Boss Spawn Point is not assigned in the Inspector");
        }
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnTime)
        {
            SpawnBoss();
            elapsedTime = 0f;
        }
    }

    void SpawnBoss()
    {
        if(bossPrefab != null && bossSpawnPoint != null)
        {
            Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);
            
            Debug.Log("Boss Spawned!");
        }
        else
        {
            Debug.LogError("Boss Prefab is not assigned in the Inspector");
        }
    }
}
